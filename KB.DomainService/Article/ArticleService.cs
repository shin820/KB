using KB.Entity;
using KB.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.DomainService.Article
{
    public class ArticleService : IArticleService
    {
        private IArticleRepository _repository;
        public ArticleService(IArticleRepository repository)
        {
            _repository = repository;
        }

        public t_KB_Article Find(int id)
        {
            return _repository.Find(id);
        }

        public IQueryable<t_KB_Article> FindAll()
        {
            return _repository.FindAll().OrderByDescending(t => t.Id);
        }

        public void Delete(int id)
        {
            t_KB_Article article = this.Find(id);
            if (article != null)
            {
                _repository.Delete(article);
            }
        }

        public void Update(t_KB_Article article)
        {
            article.ModifiedTime = DateTime.UtcNow;
            _repository.Update(article);
        }

        public void Insert(t_KB_Article article)
        {
            article.CreatedTime = DateTime.UtcNow;
            _repository.Insert(article);
        }
    }
}
