using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.Application.Dto.KB;
using KB.Domain.DomainServices;
using KB.Domain.Entities;
using System.Linq;

namespace KB.Application.AppServices
{
    public class KnowlegeBaseAppService : IKnowlegeBaseAppService
    {
        private IKnowlegeBaseService _kbDomainService;
        public KnowlegeBaseAppService(
                IKnowlegeBaseService kbDomainService
            )
        {
            _kbDomainService = kbDomainService;
        }

        public KnowlegeBaseDto Find(int id)
        {
            var article = _kbDomainService.Find(id);
            return Mapper.Map<KnowlegeBaseDto>(article);
        }

        public IQueryable<KnowlegeBaseDto> FindAll()
        {
            return _kbDomainService.FindAll()
                .ProjectTo<KnowlegeBaseDto>();
        }

        public void Delete(int id)
        {
            _kbDomainService.Delete(id);
        }

        public void Update(int id, KnowlegeBaseDto kbDto)
        {
            KnowledgeBase kb = _kbDomainService.Find(id);
            if (kb != null)
            {
                kb = Mapper.Map(kbDto, kb);
                _kbDomainService.Update(kb);
            }
        }

        public KnowlegeBaseDto Insert(KnowlegeBaseDto kbDto)
        {
            KnowledgeBase kb = Mapper.Map<KnowledgeBase>(kbDto);
            _kbDomainService.Insert(kb);

            return Mapper.Map<KnowlegeBaseDto>(kb);
        }
    }
}
