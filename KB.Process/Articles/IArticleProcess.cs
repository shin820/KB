using System.Linq;
using KB.Object.Articles;

namespace KB.Process.Articles
{
    public interface IArticleProcess
    {
        void AddTag(int articleId, int tagId);
        void Delete(int id);
        ArticleDetail Find(int id);
        IQueryable<Article> FindAll();
        Article Insert(Article articleDto);
        void RemoveTag(int articleId, int tagId);
        void Update(int id, Article articleDto);
    }
}