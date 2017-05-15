using System.Linq;
using KB.Entity;

namespace KB.DomainService.KnowlegeBase
{
    public interface IKnowlegeBaseService
    {
        void Delete(int id);
        t_KB_KnowledgeBase Find(int id);
        IQueryable<t_KB_KnowledgeBase> FindAll();
        void Insert(t_KB_KnowledgeBase kb);
        void Update(t_KB_KnowledgeBase kb);
    }
}