using System.Linq;
using KB.Object.KB;
using KB.Entity;

namespace KB.BizService.KnowlegeBases
{
    public interface IKnowlegeBaseService
    {
        void Delete(int id);
        t_KB_KnowledgeBase Find(int id);
        IQueryable<t_KB_KnowledgeBase> FindAll();
        t_KB_KnowledgeBase Insert(t_KB_KnowledgeBase kb);
        void Update(t_KB_KnowledgeBase kb);
    }
}