using KB.Application.Dto.Articles;
using System.Linq;

namespace KB.Application.AppServices
{
    public interface IArticleAppService
    {
        void AddTag(int articleId, int tagId);
        void Delete(int id);
        ArticleDetail Find(int id);
        IQueryable<ArticleInfo> FindAll();
        ArticleInfo Insert(ArticleInfo articleDto);
        void RemoveTag(int articleId, int tagId);
        void Update(int id, ArticleInfo articleDto);
    }
}