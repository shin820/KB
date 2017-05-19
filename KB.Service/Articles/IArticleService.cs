using System.Linq;
using KB.Object.Articles;
using KB.Entity;

namespace KB.BizService.Articles
{
    public interface IArticleService
    {
        void Delete(int id);
        Article Find(int id);
        IQueryable<Article> FindAll();
        Article Insert(Article createRequest);
        void Update(Article updateRequest);
        void AddTag(int articleId, int tagId);
        void RemoveTag(int articleId, int tagId);
    }
}