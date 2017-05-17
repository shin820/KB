using AutoMapper;
using AutoMapper.QueryableExtensions;
using KB.Dto.Tag;
using KB.Entity;
using KB.Repository.Repositories;
using System;
using System.Linq;

namespace KB.AppService.Tag
{
    public class TagService : ITagService
    {
        private ITagRepository _repository;
        public TagService(ITagRepository repository)
        {
            _repository = repository;
        }

        public TagDto Find(int id)
        {
            var tag = _repository.Find(id);
            return Mapper.Map<TagDto>(tag);
        }

        public IQueryable<TagDto> FindAll()
        {
            return _repository.FindAll()
                .OrderByDescending(t => t.Id)
                .ProjectTo<TagDto>(); ;
        }

        public void Delete(int id)
        {
            t_KB_Tag tag = _repository.Find(id);
            if (tag != null)
            {
                _repository.Delete(tag);
            }
        }

        public void Update(int id, TagDto tagDto)
        {
            t_KB_Tag tag = _repository.Find(id);
            if (tag != null)
            {
                tagDto.Id = id;
                tag = Mapper.Map(tagDto, tag);
                _repository.Update(tag);
            }
        }

        public TagDto Insert(TagDto tagDto)
        {
            t_KB_Tag tag = Mapper.Map<t_KB_Tag>(tagDto);

            tag.CreatedTime = DateTime.UtcNow;
            _repository.Insert(tag);

            return Mapper.Map<TagDto>(tag);
        }
    }
}
