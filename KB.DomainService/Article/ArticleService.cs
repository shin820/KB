using KB.Entity;
using KB.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.DomainService.Article
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

        public t_KB_Article Find(int id)
        {
            return _articleRepository.Find(id);
        }

        public IQueryable<t_KB_Article> FindAll()
        {
            return _articleRepository.FindAll().OrderByDescending(t => t.Id);
        }

        public void Delete(int id)
        {
            t_KB_Article article = this.Find(id);
            if (article != null)
            {
                _articleRepository.Delete(article);
            }

            var relations = _articleTagRelationRepository.FindAll().Where(t => t.ArticleId == id);
            foreach (var relation in relations)
            {
                _articleTagRelationRepository.Delete(relation);
            }
        }

        public void Update(t_KB_Article article)
        {
            article.ModifiedTime = DateTime.UtcNow;
            _articleRepository.Update(article);
        }

        public void Insert(t_KB_Article article)
        {
            article.CreatedTime = DateTime.UtcNow;
            _articleRepository.Insert(article);
        }

        public void AddTag(int articleId, int tagId)
        {
            t_KB_Article article = _articleRepository.Find(articleId);
            if (article == null)
            {
                throw new ArgumentException("Invalid article id.");
            }
            t_KB_Tag tag = _tagRepository.Find(tagId);
            if (tag == null)
            {
                throw new ArgumentException("Invalid tag id.");
            }

            //if (article.KBId != tag.KBId)
            //{
            //    throw new InvalidOperationException("Article and tag should belong to the same KB.");
            //}

            bool isExisted = _articleTagRelationRepository.FindAll()
                .Any(t => t.ArticleId == article.Id && t.TagId == tag.Id);
            if (isExisted)
            {
                throw new InvalidOperationException("Relation existed.");
            }

            var relateion = new t_KB_ArticlesTagsRelation
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
            t_KB_ArticlesTagsRelation relation = _articleTagRelationRepository
                .FindAll()
                .Where(t => t.ArticleId == articleId && t.TagId == tagId)
                .FirstOrDefault();

            if (relation != null)
            {
                _articleTagRelationRepository.Delete(relation);
            }
        }

        public IQueryable<t_KB_Tag> FindTags(int articleId)
        {
            return _articleTagRelationRepository
                 .FindAll()
                 .Where(t => t.ArticleId == articleId).Select(t => t.t_KB_Tag);
        }
    }
}
