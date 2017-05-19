using System.Linq;
using KB.Entity;

namespace KB.DomainService.Services
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