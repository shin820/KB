using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.Dto.KB;
using KB.Entity;
using KB.Repository.Repositories;
using System.Linq;

namespace KB.AppService.KnowlegeBase
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

        public KBDto Find(int id)
        {
            var article = _repository.Find(id);
            return Mapper.Map<KBDto>(article);
        }

        public IQueryable<KBDto> FindAll()
        {
            return _repository.FindAll()
                .OrderByDescending(t => t.Id)
                .ProjectTo<KBDto>(); ;
        }

        public void Delete(int id)
        {
            t_KB_KnowledgeBase kb = _repository.Find(id);
            if (kb != null)
            {
                _repository.Delete(kb);
            }
        }

        public void Update(int id, KBDto kbDto)
        {
            t_KB_KnowledgeBase kb = _repository.Find(id);
            if (kb != null)
            {
                kbDto.Id = id;
                kb = Mapper.Map(kbDto, kb);
                _repository.Update(kb);
            }
        }

        public KBDto Insert(KBDto kbDto)
        {
            t_KB_KnowledgeBase kb = Mapper.Map<t_KB_KnowledgeBase>(kbDto);
            _repository.Insert(kb);

            return Mapper.Map<KBDto>(kb);
        }
    }
}
