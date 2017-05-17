using System.Linq;
using KB.Dto.Article;

namespace KB.Service.AppServices
{
    public interface IArticleAppService
    {
        void Delete(int id);
        ArticleDetailDto Find(int id);
        IQueryable<ArticleDto> FindAll();
        ArticleDto Insert(ArticleDto createRequest);
        void Update(int id, ArticleDto updateRequest);
        void AddTag(int articleId, int tagId);
        void RemoveTag(int articleId, int tagId);
    }
}