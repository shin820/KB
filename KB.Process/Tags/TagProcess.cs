﻿using AutoMapper;
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

        public TagInfo Find(int id)
        {
            var tag = _tagService.Find(id);
            return Mapper.Map<TagInfo>(tag);
        }

        public IQueryable<TagInfo> FindAll()
        {
            return _tagService.FindAll()
                .ProjectTo<TagInfo>(); ;
        }

        public void Delete(int id)
        {
            _tagService.Delete(id);
        }

        public void Update(int id, TagInfo tagDto)
        {
            Tag tag = _tagService.Find(id);
            if (tag != null)
            {
                tagDto.Id = id;
                tag = Mapper.Map(tagDto, tag);
                _tagService.Update(tag);
            }
        }

        public TagInfo Insert(TagInfo tagDto)
        {
            Tag tag = Mapper.Map<Tag>(tagDto);
            _tagService.Insert(tag);

            return Mapper.Map<TagInfo>(tag);
        }
    }
}
