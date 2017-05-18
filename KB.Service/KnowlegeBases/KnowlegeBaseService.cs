using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.Object.KB;
using KB.Entity;
using KB.Repository.KnowlegeBases;
using System.Linq;

namespace KB.BizService.KnowlegeBases
{
    public class KnowlegeBaseService : IKnowlegeBaseService
    {
        private IKnowlegeBaseRepository _repository;
        public KnowlegeBaseService(
                IKnowlegeBaseRepository repository
            )
        {
            _repository = repository;
        }

        public t_KB_KnowledgeBase Find(int id)
        {
            return _repository.Find(id);
        }

        public IQueryable<t_KB_KnowledgeBase> FindAll()
        {
            return _repository.FindAll()
                .OrderByDescending(t => t.Id);
        }

        public void Delete(int id)
        {
            t_KB_KnowledgeBase kb = _repository.Find(id);
            if (kb != null)
            {
                _repository.Delete(kb);
            }
        }

        public void Update(t_KB_KnowledgeBase kb)
        {
            _repository.Update(kb);
        }

        public t_KB_KnowledgeBase Insert(t_KB_KnowledgeBase kb)
        {
            _repository.Insert(kb);
            return kb;
        }
    }
}
