using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.DomainService.KnowlegeBase;
using KB.Dto.KB;
using KB.Entity;
using System.Linq;

namespace KB.AppService.KnowlegeBase
{
    public class KnowlegeBaseAppService : IKnowlegeBaseAppService
    {
        private IKnowlegeBaseService _kbService;
        public KnowlegeBaseAppService(IKnowlegeBaseService kbService)
        {
            _kbService = kbService;
        }

        public KBDetailResponse Find(int id)
        {
            var article = _kbService.Find(id);
            return Mapper.Map<KBDetailResponse>(article);
        }

        public IQueryable<KBListResponse> FindAll()
        {
            return _kbService.FindAll()
                .OrderByDescending(t => t.Id)
                .ProjectTo<KBListResponse>(); ;
        }

        public void Delete(int id)
        {
            _kbService.Delete(id);
        }

        public void Update(int id, KBUpdateRequest updateRequest)
        {
            t_KB_KnowledgeBase kb = this._kbService.Find(id);
            if (kb != null)
            {
                kb = Mapper.Map(updateRequest, kb);
                _kbService.Update(kb);
            }
        }

        public KBDetailResponse Insert(KBCreateRequest createRequest)
        {
            t_KB_KnowledgeBase kb = Mapper.Map<t_KB_KnowledgeBase>(createRequest);
            _kbService.Insert(kb);

            return Mapper.Map<KBDetailResponse>(kb);
        }
    }
}
