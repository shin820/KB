using KB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.DomainService.Article
{
    public interface IArticleService
    {
        void Delete(int id);
        t_KB_Article Find(int id);
        IQueryable<t_KB_Article> FindAll();
        void Update(t_KB_Article article);
        void Insert(t_KB_Article article);
        void AddTag(int articleId, int tagId);
        void RemoveTag(int articleId, int tagId);
    }
}
