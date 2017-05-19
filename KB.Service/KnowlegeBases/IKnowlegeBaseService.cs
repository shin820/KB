using System.Linq;
using KB.Object.KB;
using KB.Entity;

namespace KB.BizService.KnowlegeBases
{
    public interface IKnowlegeBaseService
    {
        void Delete(int id);
        KnowledgeBase Find(int id);
        IQueryable<KnowledgeBase> FindAll();
        KnowledgeBase Insert(KnowledgeBase kb);
        void Update(KnowledgeBase kb);
    }
}