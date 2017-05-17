using System.Linq;
using KB.Object.KB;

namespace KB.BizService.KnowlegeBases
{
    public interface IKnowlegeBaseService
    {
        void Delete(int id);
        KnowlegeBase Find(int id);
        IQueryable<KnowlegeBase> FindAll();
        KnowlegeBase Insert(KnowlegeBase createRequest);
        void Update(int id, KnowlegeBase updateRequest);
    }
}