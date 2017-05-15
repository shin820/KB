using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.DomainService.KnowlegeBase;
using KB.DomainService.Tag;
using KB.Dto.KB;
using KB.Dto.Tag;
using KB.Entity;
using System.Linq;

namespace KB.AppService.Tag
{
    public class TagAppService : ITagAppService
    {
        private ITagService _tagService;
        public TagAppService(ITagService tagService)
        {
            _tagService = tagService;
        }

        public TagDetailResponse Find(int id)
        {
            var tag = _tagService.Find(id);
            return Mapper.Map<TagDetailResponse>(tag);
        }

        public IQueryable<TagListResponse> FindAll()
        {
            return _tagService.FindAll()
                .OrderByDescending(t => t.Id)
                .ProjectTo<TagListResponse>(); ;
        }

        public void Delete(int id)
        {
            _tagService.Delete(id);
        }

        public void Update(int id, TagUpdateRequest updateRequest)
        {
            t_KB_Tag tag = this._tagService.Find(id);
            if (tag != null)
            {
                tag = Mapper.Map(updateRequest, tag);
                _tagService.Update(tag);
            }
        }

        public TagDetailResponse Insert(TagCreateRequest createRequest)
        {
            t_KB_Tag tag = Mapper.Map<t_KB_Tag>(createRequest);
            _tagService.Insert(tag);

            return Mapper.Map<TagDetailResponse>(tag);
        }
    }
}
