﻿using System.Linq;
using KB.Object.Tags;

namespace KB.Process.Tags
{
    public interface ITagProcess
    {
        void Delete(int id);
        TagInfo Find(int id);
        IQueryable<TagInfo> FindAll();
        TagInfo Insert(TagInfo tagDto);
        void Update(int id, TagInfo tagDto);
    }
}