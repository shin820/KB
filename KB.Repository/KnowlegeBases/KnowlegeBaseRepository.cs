using KB.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Repository.KnowlegeBases
{
    public class KnowlegeBaseRepository : RepositoryBase<t_KB_KnowledgeBase>, IKnowlegeBaseRepository
    {
        public KnowlegeBaseRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
