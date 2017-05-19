using KB.Application.Dto.KB;
using System.Linq;

namespace KB.Application.AppServices
{
    public interface IKnowlegeBaseAppService
    {
        void Delete(int id);
        KnowlegeBaseDto Find(int id);
        IQueryable<KnowlegeBaseDto> FindAll();
        KnowlegeBaseDto Insert(KnowlegeBaseDto kbDto);
        void Update(int id, KnowlegeBaseDto kbDto);
    }
}