using KB.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Repository.Repositories
{
    public class KnowlegeBaseRepository : RepositoryBase<KnowledgeBase>, IKnowlegeBaseRepository
    {
        public KnowlegeBaseRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
