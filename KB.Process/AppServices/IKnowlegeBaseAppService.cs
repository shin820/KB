using KB.ApplicationService.Dto.KB;
using System.Linq;

namespace KB.ApplicationService.AppServices
{
    public interface IKnowlegeBaseAppService
    {
        void Delete(int id);
        KnowlegeBaseInfo Find(int id);
        IQueryable<KnowlegeBaseInfo> FindAll();
        KnowlegeBaseInfo Insert(KnowlegeBaseInfo kbDto);
        void Update(int id, KnowlegeBaseInfo kbDto);
    }
}