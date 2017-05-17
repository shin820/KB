using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.Object.Articles;
using KB.Object.Tags;
using KB.Entity;
using KB.Repository.Articles;
using KB.Repository.Tags;
using System;
using System.Linq;
using System.Transactions;

namespace KB.BizService.Articles
{
    public class ArticleAppService : IArticleAppService
    {
        private IArticleRepository _articleRepository;
        private ITagRepository _tagRepository;
        private IArticlesTagsRelationRepository _articleTagRelationRepository;


        public ArticleAppService(
            IArticleRepository articleRepository,
            ITagRepository tagRepository,
            IArticlesTagsRelationRepository articleTagRelationRepository
            )
        {
            _articleRepository = articleRepository;
            _tagRepository = tagRepository;
            _articleTagRelationRepository = articleTagRelationRepository;
        }

        public ArticleDetail Find(int id)
        {
            var article = _articleRepository.Find(id);
            var articleDto = Mapper.Map<ArticleDetail>(article);
            articleDto.Tags = _articleTagRelationRepository
                 .FindAll()
                 .Where(t => t.ArticleId == id)
                 .Select(t => t.t_KB_Tag)
                 .ProjectTo<Tag>()
                 .ToList();

            return articleDto;
        }

        public IQueryable<Article> FindAll()
        {
            return _articleRepository.FindAll()
                .OrderByDescending(t => t.Id)
                .ProjectTo<Article>();
        }

        public void Delete(int id)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                t_KB_Article article = _articleRepository.Find(id);
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

        public void Update(int id, Article articleDto)
        {
            t_KB_Article article = _articleRepository.Find(id);
            if (article != null)
            {
                article = Mapper.Map(articleDto, article);
                article.Id = id;
                article.ModifiedTime = DateTime.UtcNow;
                _articleRepository.Update(article);
            }
        }

        public Article Insert(Article articleDto)
        {
            t_KB_Article article = Mapper.Map<t_KB_Article>(articleDto);
            article.CreatedTime = DateTime.UtcNow;
            _articleRepository.Insert(article);

            return Mapper.Map<Article>(article);
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
    }
}
