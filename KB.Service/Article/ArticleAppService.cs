using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.DomainService.Article;
using KB.Dto.Article;
using KB.Entity;
using System.Linq;

namespace KB.Service.AppServices
{
    public class ArticleAppService : IArticleAppService
    {
        private IArticleService _articleService;
        public ArticleAppService(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public ArticleDetailResponse Find(int id)
        {
            var article = _articleService.Find(id);
            return Mapper.Map<ArticleDetailResponse>(article);
        }

        public IQueryable<ArticleListReponse> FindAll()
        {
            return _articleService.FindAll()
                .OrderByDescending(t => t.Id)
                .ProjectTo<ArticleListReponse>(); ;
        }

        public void Delete(int id)
        {
            _articleService.Delete(id);
        }

        public void Update(int id, ArticleUpdateRequest updateRequest)
        {
            t_KB_Article article = this._articleService.Find(id);
            if (article != null)
            {
                article = Mapper.Map(updateRequest, article);
                _articleService.Update(article);
            }
        }

        public ArticleDetailResponse Insert(ArticleCreateRequest createRequest)
        {
            t_KB_Article article = Mapper.Map<t_KB_Article>(createRequest);
            _articleService.Insert(article);

            return Mapper.Map<ArticleDetailResponse>(article);
        }
    }
}
