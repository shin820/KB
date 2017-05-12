using KB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Repository.Repositories
{
    public class ArticleRepository : RepositoryBase<t_KB_Article>, IArticleRepository
    {
        public ArticleRepository(KBDataContext dbContext) : base(dbContext)
        {
        }
    }
}
