using System.Linq;
using KB.Dto.KB;

namespace KB.AppService.KnowlegeBase
{
    public interface IKnowlegeBaseAppService
    {
        void Delete(int id);
        KBDetailResponse Find(int id);
        IQueryable<KBListResponse> FindAll();
        KBDetailResponse Insert(KBCreateRequest createRequest);
        void Update(int id, KBUpdateRequest updateRequest);
    }
}