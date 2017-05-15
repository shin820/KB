using System.Linq;
using KB.Entity;

namespace KB.DomainService.Tag
{
    public interface ITagService
    {
        void Delete(int id);
        t_KB_Tag Find(int id);
        IQueryable<t_KB_Tag> FindAll();
        void Insert(t_KB_Tag tag);
        void Update(t_KB_Tag tag);
    }
}