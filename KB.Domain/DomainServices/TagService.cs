using KB.Domain.Entities;
using KB.Domain.Repositories;
using System;
using System.Linq;

namespace KB.Domain.DomainServices
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
            return _repository.Find(id);
        }

        public IQueryable<Tag> FindAll()
        {
            return _repository.FindAll()
                .OrderByDescending(t => t.Id);
        }

        public void Delete(int id)
        {
            Tag tag = _repository.Find(id);
            if (tag != null)
            {
                _repository.Delete(tag);
            }
        }

        public void Update(Tag tag)
        {
            _repository.Update(tag);
        }

        public Tag Insert(Tag tag)
        {
            tag.CreatedTime = DateTime.UtcNow;
            _repository.Insert(tag);

            return tag;
        }
    }
}
