using KB.Domain.Entities;
using System.Data.Entity;

namespace KB.Domain.Repositories
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
