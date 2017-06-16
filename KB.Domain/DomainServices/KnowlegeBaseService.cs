using KB.Domain.Entities;
using KB.Domain.Repositories;
using System.Linq;

namespace KB.Domain.DomainServices
{
    public class KnowlegeBaseService : IKnowlegeBaseService, IDomainService
    {
        private IKnowlegeBaseRepository _repository;
        public KnowlegeBaseService(
                IKnowlegeBaseRepository repository
            )
        {
            _repository = repository;
        }

        public KnowledgeBase Find(int id)
        {
            return _repository.Find(id);
        }

        public IQueryable<KnowledgeBase> FindAll()
        {
            return _repository.FindAll()
                .OrderByDescending(t => t.Id);
        }

        public void Delete(int id)
        {
            KnowledgeBase kb = _repository.Find(id);
            if (kb != null)
            {
                _repository.Delete(kb);
            }
        }

        public void Update(KnowledgeBase kb)
        {
            _repository.Update(kb);
        }

        public KnowledgeBase Insert(KnowledgeBase kb)
        {
            _repository.Insert(kb);
            return kb;
        }
    }
}
