using System.Linq;
using KB.Object.Tags;
using KB.Entity;

namespace KB.BizService.Tags
{
    public interface ITagService
    {
        void Delete(int id);
        t_KB_Tag Find(int id);
        IQueryable<t_KB_Tag> FindAll();
        t_KB_Tag Insert(t_KB_Tag tag);
        void Update(t_KB_Tag tag);
    }
}