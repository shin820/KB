using System.Linq;
using KB.Dto.Article;

namespace KB.Service.AppServices
{
    public interface IArticleAppService
    {
        void Delete(int id);
        ArticleDetailResponse Find(int id);
        IQueryable<ArticleListResponse> FindAll();
        ArticleDetailResponse Insert(ArticleCreateRequest createRequest);
        void Update(int id, ArticleUpdateRequest updateRequest);
        void AddTag(int articleId, int tagId);
        void RemoveTag(int articleId, int tagId);
    }
}