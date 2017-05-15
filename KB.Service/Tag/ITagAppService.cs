using System.Linq;
using KB.Dto.Tag;

namespace KB.AppService.Tag
{
    public interface ITagAppService
    {
        void Delete(int id);
        TagDetailResponse Find(int id);
        IQueryable<TagListResponse> FindAll();
        TagDetailResponse Insert(TagCreateRequest createRequest);
        void Update(int id, TagUpdateRequest updateRequest);
    }
}