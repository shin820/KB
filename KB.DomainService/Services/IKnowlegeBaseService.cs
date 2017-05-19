using System.Linq;
using KB.Domain.Entities;

namespace KB.Domain.Services
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