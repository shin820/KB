using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.ApplicationService.Dto.Articles;
using KB.DomainService.Services;
using KB.Entity;
using System.Linq;

namespace KB.ApplicationService.AppServices
{
    public class ArticleAppService : IArticleAppService
    {
        private IArticleService _articleService;
        public ArticleAppService(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public ArticleDetail Find(int id)
        {
            var article = _articleService.Find(id);
            var articleDto = Mapper.Map<ArticleDetail>(article);
            return articleDto;
        }

        public IQueryable<ArticleInfo> FindAll()
        {
            return _articleService.FindAll()
                .ProjectTo<ArticleInfo>();
        }

        public void Delete(int id)
        {
            _articleService.Delete(id);
        }

        public void Update(int id, ArticleInfo articleDto)
        {
            Article article = _articleService.Find(id);
            if (article != null)
            {
                articleDto.Id = id;
                article = Mapper.Map(articleDto, article);
                _articleService.Update(article);
            }
        }

        public ArticleInfo Insert(ArticleInfo articleDto)
        {
            Article article = Mapper.Map<Article>(articleDto);
            _articleService.Insert(article);

            return Mapper.Map<ArticleInfo>(article);
        }

        public void AddTag(int articleId, int tagId)
        {
            _articleService.AddTag(articleId, tagId);
        }

        public void RemoveTag(int articleId, int tagId)
        {
            _articleService.RemoveTag(articleId, tagId);
        }
    }
}
