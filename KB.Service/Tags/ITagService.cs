using System.Linq;
using KB.Object.Tags;
using KB.Entity;

namespace KB.BizService.Tags
{
    public interface ITagService
    {
        void Delete(int id);
        Tag Find(int id);
        IQueryable<Tag> FindAll();
        Tag Insert(Tag tag);
        void Update(Tag tag);
    }
}