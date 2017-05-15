using KB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Repository.Repositories
{
    public class ArticlesTagsRelationRepository : RepositoryBase<t_KB_ArticlesTagsRelation>, IArticlesTagsRelationRepository
    {
        public ArticlesTagsRelationRepository(KBDataContext dbContext) : base(dbContext)
        {
        }
    }

    public interface IArticlesTagsRelationRepository : IRepositoryBase<t_KB_ArticlesTagsRelation>
    {

    }
}
