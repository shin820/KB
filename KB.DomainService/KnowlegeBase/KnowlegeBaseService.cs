using KB.Entity;
using KB.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.DomainService.KnowlegeBase
{
    public class KnowlegeBaseService : IKnowlegeBaseService
    {
        private IKnowlegeBaseRepository _repository;
        public KnowlegeBaseService(IKnowlegeBaseRepository repository)
        {
            _repository = repository;
        }

        public t_KB_KnowledgeBase Find(int id)
        {
            return _repository.Find(id);
        }

        public IQueryable<t_KB_KnowledgeBase> FindAll()
        {
            return _repository.FindAll().OrderByDescending(t => t.Id);
        }

        public void Delete(int id)
        {
            t_KB_KnowledgeBase kb = this.Find(id);
            if (kb != null)
            {
                _repository.Delete(kb);
            }
        }

        public void Update(t_KB_KnowledgeBase kb)
        {
            _repository.Update(kb);
        }

        public void Insert(t_KB_KnowledgeBase kb)
        {
            _repository.Insert(kb);
        }
    }
}
