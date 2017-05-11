using System.Linq;
using KB.Entity;

namespace KB.Service.AppServices
{
    public interface IArticleAppService
    {
        void Delete(t_KB_Article message);
        t_KB_Article Find(int id);
        IQueryable<t_KB_Article> FindAll();
        void Update(t_KB_Article message);
        void Insert(t_KB_Article message);
    }
}