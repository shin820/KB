using KB.Application.Dto.Articles;
using System.Linq;

namespace KB.Application.AppServices
{
    public interface IArticleAppService
    {
        void AddTag(int articleId, int tagId);
        void Delete(int id);
        ArticleDetailDto Find(int id);
        IQueryable<ArticleDto> FindAll();
        ArticleDto Insert(ArticleDto articleDto);
        void RemoveTag(int articleId, int tagId);
        void Update(int id, ArticleDto articleDto);
    }
}