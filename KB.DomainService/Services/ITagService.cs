using System.Linq;
using KB.Domain.Entities;

namespace KB.Domain.Services
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