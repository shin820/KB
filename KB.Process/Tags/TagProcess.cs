using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.BizService.Tags;
using KB.Entity;
using KB.Object.Tags;
using System.Linq;

namespace KB.Process.Tags
{
    public class TagProcess : ITagProcess
    {
        private ITagService _tagService;
        public TagProcess(ITagService tagService)
        {
            _tagService = tagService;
        }

        public Tag Find(int id)
        {
            var tag = _tagService.Find(id);
            return Mapper.Map<Tag>(tag);
        }

        public IQueryable<Tag> FindAll()
        {
            return _tagService.FindAll()
                .ProjectTo<Tag>(); ;
        }

        public void Delete(int id)
        {
            _tagService.Delete(id);
        }

        public void Update(int id, Tag tagDto)
        {
            t_KB_Tag tag = _tagService.Find(id);
            if (tag != null)
            {
                tagDto.Id = id;
                tag = Mapper.Map(tagDto, tag);
                _tagService.Update(tag);
            }
        }

        public Tag Insert(Tag tagDto)
        {
            t_KB_Tag tag = Mapper.Map<t_KB_Tag>(tagDto);
            _tagService.Insert(tag);

            return Mapper.Map<Tag>(tag);
        }
    }
}
