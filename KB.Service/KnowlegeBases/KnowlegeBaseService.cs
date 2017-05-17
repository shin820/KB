using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.Object.KB;
using KB.Entity;
using KB.Repository.Repositories;
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

        public KnowlegeBase Find(int id)
        {
            var article = _repository.Find(id);
            return Mapper.Map<KnowlegeBase>(article);
        }

        public IQueryable<KnowlegeBase> FindAll()
        {
            return _repository.FindAll()
                .OrderByDescending(t => t.Id)
                .ProjectTo<KnowlegeBase>(); ;
        }

        public void Delete(int id)
        {
            t_KB_KnowledgeBase kb = _repository.Find(id);
            if (kb != null)
            {
                _repository.Delete(kb);
            }
        }

        public void Update(int id, KnowlegeBase kbDto)
        {
            t_KB_KnowledgeBase kb = _repository.Find(id);
            if (kb != null)
            {
                kbDto.Id = id;
                kb = Mapper.Map(kbDto, kb);
                _repository.Update(kb);
            }
        }

        public KnowlegeBase Insert(KnowlegeBase kbDto)
        {
            t_KB_KnowledgeBase kb = Mapper.Map<t_KB_KnowledgeBase>(kbDto);
            _repository.Insert(kb);

            return Mapper.Map<KnowlegeBase>(kb);
        }
    }
}
