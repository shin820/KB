using System.Linq;
using KB.Object.Tags;

namespace KB.Process.Tags
{
    public interface ITagProcess
    {
        void Delete(int id);
        Tag Find(int id);
        IQueryable<Tag> FindAll();
        Tag Insert(Tag tagDto);
        void Update(int id, Tag tagDto);
    }
}