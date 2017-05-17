using System.Linq;
using KB.Dto.Tag;

namespace KB.AppService.Tag
{
    public interface ITagService
    {
        void Delete(int id);
        TagDto Find(int id);
        IQueryable<TagDto> FindAll();
        TagDto Insert(TagDto createRequest);
        void Update(int id, TagDto updateRequest);
    }
}