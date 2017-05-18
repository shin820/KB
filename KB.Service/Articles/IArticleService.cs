using System.Linq;
using KB.Object.Articles;
using KB.Entity;

namespace KB.BizService.Articles
{
    public interface IArticleService
    {
        void Delete(int id);
        t_KB_Article Find(int id);
        IQueryable<t_KB_Article> FindAll();
        t_KB_Article Insert(t_KB_Article createRequest);
        void Update(t_KB_Article updateRequest);
        void AddTag(int articleId, int tagId);
        void RemoveTag(int articleId, int tagId);
    }
}