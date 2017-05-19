using System.Linq;
using KB.Entity;

namespace KB.DomainService.Services
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