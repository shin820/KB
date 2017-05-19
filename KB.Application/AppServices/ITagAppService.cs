using KB.Application.Dto.Tags;
using System.Linq;

namespace KB.Application.AppServices
{
    public interface ITagAppService
    {
        void Delete(int id);
        TagDto Find(int id);
        IQueryable<TagDto> FindAll();
        TagDto Insert(TagDto tagDto);
        void Update(int id, TagDto tagDto);
    }
}