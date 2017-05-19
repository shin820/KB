using KB.Domain.Entities;
using System.Data.Entity;

namespace KB.Domain.Repositories
{
    public class KnowlegeBaseRepository : RepositoryBase<KnowledgeBase>, IKnowlegeBaseRepository
    {
        public KnowlegeBaseRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
