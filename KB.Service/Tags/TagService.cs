using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.Object.Tags;
using KB.Entity;
using KB.Repository.Tags;
using System;
using System.Linq;

namespace KB.BizService.Tags
{
    public class TagService : ITagService
    {
        private ITagRepository _repository;
        public TagService(ITagRepository repository)
        {
            _repository = repository;
        }

        public Tag Find(int id)
        {
            var tag = _repository.Find(id);
            return Mapper.Map<Tag>(tag);
        }

        public IQueryable<Tag> FindAll()
        {
            return _repository.FindAll()
                .OrderByDescending(t => t.Id)
                .ProjectTo<Tag>(); ;
        }

        public void Delete(int id)
        {
            t_KB_Tag tag = _repository.Find(id);
            if (tag != null)
            {
                _repository.Delete(tag);
            }
        }

        public void Update(int id, Tag tagDto)
        {
            t_KB_Tag tag = _repository.Find(id);
            if (tag != null)
            {
                tag = Mapper.Map(tagDto, tag);
                tag.Id = id;
                _repository.Update(tag);
            }
        }

        public Tag Insert(Tag tagDto)
        {
            t_KB_Tag tag = Mapper.Map<t_KB_Tag>(tagDto);

            tag.CreatedTime = DateTime.UtcNow;
            _repository.Insert(tag);

            return Mapper.Map<Tag>(tag);
        }
    }
}
