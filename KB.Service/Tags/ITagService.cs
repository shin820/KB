using System.Linq;
using KB.Object.Tags;

namespace KB.BizService.Tags
{
    public interface ITagService
    {
        void Delete(int id);
        Tag Find(int id);
        IQueryable<Tag> FindAll();
        Tag Insert(Tag createRequest);
        void Update(int id, Tag updateRequest);
    }
}