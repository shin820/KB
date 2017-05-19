using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.Application.Dto.Articles;
using KB.Domain.Entities;
using KB.Domain.DomainServices;
using System.Linq;

namespace KB.Application.AppServices
{
    public class ArticleAppService : IArticleAppService
    {
        private IArticleService _articleDomainService;
        public ArticleAppService(IArticleService articleDomainService)
        {
            _articleDomainService = articleDomainService;
        }

        public ArticleDetailDto Find(int id)
        {
            var article = _articleDomainService.Find(id);
            var articleDto = Mapper.Map<ArticleDetailDto>(article);
            return articleDto;
        }

        public IQueryable<ArticleDto> FindAll()
        {
            return _articleDomainService.FindAll()
                .ProjectTo<ArticleDto>();
        }

        public void Delete(int id)
        {
            _articleDomainService.Delete(id);
        }

        public void Update(int id, ArticleDto articleDto)
        {
            Article article = _articleDomainService.Find(id);
            if (article != null)
            {
                articleDto.Id = id;
                article = Mapper.Map(articleDto, article);
                _articleDomainService.Update(article);
            }
        }

        public ArticleDto Insert(ArticleDto articleDto)
        {
            Article article = Mapper.Map<Article>(articleDto);
            _articleDomainService.Insert(article);

            return Mapper.Map<ArticleDto>(article);
        }

        public void AddTag(int articleId, int tagId)
        {
            _articleDomainService.AddTag(articleId, tagId);
        }

        public void RemoveTag(int articleId, int tagId)
        {
            _articleDomainService.RemoveTag(articleId, tagId);
        }
    }
}
