using KB.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Repository.Repositories
{
    public class ArticleRepository : RepositoryBase<t_KB_Article>, IArticleRepository
    {
        public ArticleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }

    public interface IArticleRepository : IRepositoryBase<t_KB_Article>
    {

    }
}
