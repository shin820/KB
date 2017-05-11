using KB.Entity;
using KB.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Service.AppServices
{
    public class ArticleAppService : IArticleAppService
    {
        private IArticleRepository _repository;
        public ArticleAppService(IArticleRepository repository)
        {
            _repository = repository;
        }

        public t_KB_Article Find(int id)
        {
            return _repository.Find(id);
        }

        public IQueryable<t_KB_Article> FindAll()
        {
            return _repository.FindAll().OrderByDescending(t=>t.Id);
        }

        public void Delete(t_KB_Article message)
        {
            _repository.Delete(message);
        }

        public void Update(t_KB_Article message)
        {
            _repository.Update(message);
        }

        public void Insert(t_KB_Article message)
        {
            _repository.Insert(message);
        }
    }
}
