using KB.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Repository.Articles
{
    public class ArticlesTagsRelationRepository : RepositoryBase<ArticleTags>, IArticlesTagsRelationRepository
    {
        public ArticlesTagsRelationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
