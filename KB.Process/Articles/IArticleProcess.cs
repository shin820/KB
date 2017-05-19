using System.Linq;
using KB.Object.Articles;

namespace KB.Process.Articles
{
    public interface IArticleProcess
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