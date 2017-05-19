using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.Application.Dto.Tags;
using KB.Domain.DomainServices;
using KB.Domain.Entities;
using System.Linq;

namespace KB.Application.AppServices
{
    public class TagAppService : ITagAppService
    {
        private ITagService _tagDomainService;
        public TagAppService(ITagService tagDomainService)
        {
            _tagDomainService = tagDomainService;
        }

        public TagDto Find(int id)
        {
            var tag = _tagDomainService.Find(id);
            return Mapper.Map<TagDto>(tag);
        }

        public IQueryable<TagDto> FindAll()
        {
            return _tagDomainService.FindAll()
                .ProjectTo<TagDto>(); ;
        }

        public void Delete(int id)
        {
            _tagDomainService.Delete(id);
        }

        public void Update(int id, TagDto tagDto)
        {
            Tag tag = _tagDomainService.Find(id);
            if (tag != null)
            {
                tagDto.Id = id;
                tag = Mapper.Map(tagDto, tag);
                _tagDomainService.Update(tag);
            }
        }

        public TagDto Insert(TagDto tagDto)
        {
            Tag tag = Mapper.Map<Tag>(tagDto);
            _tagDomainService.Insert(tag);

            return Mapper.Map<TagDto>(tag);
        }
    }
}
