using KB.Application.Dto.Tags;
using System.Linq;

namespace KB.Application.AppServices
{
    public interface ITagAppService
    {
        void Delete(int id);
        TagInfo Find(int id);
        IQueryable<TagInfo> FindAll();
        TagInfo Insert(TagInfo tagDto);
        void Update(int id, TagInfo tagDto);
    }
}