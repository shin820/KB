using KB.Domain.Entities;
using System.Data.Entity;

namespace KB.Domain.Repositories
{
    public class ArticlesTagsRelationRepository : RepositoryBase<ArticleTags>, IArticlesTagsRelationRepository
    {
        public ArticlesTagsRelationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
