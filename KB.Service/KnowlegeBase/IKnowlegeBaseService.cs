using System.Linq;
using KB.Dto.KB;

namespace KB.AppService.KnowlegeBase
{
    public interface IKnowlegeBaseService
    {
        void Delete(int id);
        KBDto Find(int id);
        IQueryable<KBDto> FindAll();
        KBDto Insert(KBDto createRequest);
        void Update(int id, KBDto updateRequest);
    }
}