using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.Application.Dto.KB;
using KB.Domain.Services;
using KB.Domain.Entities;
using System.Linq;

namespace KB.Application.Services
{
    public class KnowlegeBaseAppService : IKnowlegeBaseAppService
    {
        private IKnowlegeBaseService _service;
        public KnowlegeBaseAppService(
                IKnowlegeBaseService service
            )
        {
            _service = service;
        }

        public KnowlegeBaseInfo Find(int id)
        {
            var article = _service.Find(id);
            return Mapper.Map<KnowlegeBaseInfo>(article);
        }

        public IQueryable<KnowlegeBaseInfo> FindAll()
        {
            return _service.FindAll()
                .ProjectTo<KnowlegeBaseInfo>();
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public void Update(int id, KnowlegeBaseInfo kbDto)
        {
            KnowledgeBase kb = _service.Find(id);
            if (kb != null)
            {
                kb.Id = id;
                kb = Mapper.Map(kbDto, kb);
                _service.Update(kb);
            }
        }

        public KnowlegeBaseInfo Insert(KnowlegeBaseInfo kbDto)
        {
            KnowledgeBase kb = Mapper.Map<KnowledgeBase>(kbDto);
            _service.Insert(kb);

            return Mapper.Map<KnowlegeBaseInfo>(kb);
        }
    }
}
