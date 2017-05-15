using KB.Entity;
using KB.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.DomainService.Tag
{
    public class TagService : ITagService
    {
        private ITagRepository _repository;
        public TagService(ITagRepository repository)
        {
            _repository = repository;
        }

        public t_KB_Tag Find(int id)
        {
            return _repository.Find(id);
        }

        public IQueryable<t_KB_Tag> FindAll()
        {
            return _repository.FindAll().OrderByDescending(t => t.Id);
        }

        public void Delete(int id)
        {
            t_KB_Tag tag = this.Find(id);
            if (tag != null)
            {
                _repository.Delete(tag);
            }
        }

        public void Update(t_KB_Tag tag)
        {
            _repository.Update(tag);
        }

        public void Insert(t_KB_Tag tag)
        {
            tag.CreatedTime = DateTime.UtcNow;
            _repository.Insert(tag);
        }
    }
}
