using KB.Entity;
using KB.Repository.Articles;
using KB.Repository.Tags;
using System;
using System.Linq;
using System.Transactions;

namespace KB.DomainService.Articles
{
    public class ArticleService : IArticleService
    {
        private IArticleRepository _articleRepository;
        private ITagRepository _tagRepository;
        private IArticlesTagsRelationRepository _articleTagRelationRepository;


        public ArticleService(
            IArticleRepository articleRepository,
            ITagRepository tagRepository,
            IArticlesTagsRelationRepository articleTagRelationRepository
            )
        {
            _articleRepository = articleRepository;
            _tagRepository = tagRepository;
            _articleTagRelationRepository = articleTagRelationRepository;
        }

        public Article Find(int id)
        {
            return _articleRepository.Find(id);
        }

        public IQueryable<Article> FindAll()
        {
            return _articleRepository.FindAll()
                .OrderByDescending(t => t.Id);
        }

        public void Delete(int id)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                Article article = _articleRepository.Find(id);
                if (article != null)
                {
                    _articleRepository.Delete(article);
                }

                var relations = _articleTagRelationRepository.FindAll().Where(t => t.ArticleId == id);
                foreach (var relation in relations)
                {
                    _articleTagRelationRepository.Delete(relation);
                }

                transactionScope.Complete();
            }
        }

        public void Update(Article article)
        {
            article.ModifiedTime = DateTime.UtcNow;
            _articleRepository.Update(article);
        }

        public Article Insert(Article article)
        {
            article.CreatedTime = DateTime.UtcNow;
            _articleRepository.Insert(article);

            return article;
        }

        public void AddTag(int articleId, int tagId)
        {
            Article article = _articleRepository.Find(articleId);
            if (article == null)
            {
                throw new ArgumentException("Invalid article id.");
            }
            Tag tag = _tagRepository.Find(tagId);
            if (tag == null)
            {
                throw new ArgumentException("Invalid tag id.");
            }

            bool isExisted = _articleTagRelationRepository.FindAll()
                .Any(t => t.ArticleId == article.Id && t.TagId == tag.Id);
            if (isExisted)
            {
                throw new InvalidOperationException("Relation existed.");
            }

            var relateion = new ArticleTags
            {
                ArticleId = article.Id,
                TagId = tag.Id,
                KBId = article.KBId,
                SiteId = article.SiteId
            };

            _articleTagRelationRepository.Insert(relateion);
        }

        public void RemoveTag(int articleId, int tagId)
        {
            ArticleTags relation = _articleTagRelationRepository
                .FindAll()
                .Where(t => t.ArticleId == articleId && t.TagId == tagId)
                .FirstOrDefault();

            if (relation != null)
            {
                _articleTagRelationRepository.Delete(relation);
            }
        }
    }
}
