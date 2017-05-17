using System.Linq;
using KB.Object.Articles;

namespace KB.BizService.Articles
{
    public interface IArticleAppService
    {
        void Delete(int id);
        ArticleDetail Find(int id);
        IQueryable<Article> FindAll();
        Article Insert(Article createRequest);
        void Update(int id, Article updateRequest);
        void AddTag(int articleId, int tagId);
        void RemoveTag(int articleId, int tagId);
    }
}