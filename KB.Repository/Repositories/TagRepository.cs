using KB.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Repository.Repositories
{
    public class TagRepository : RepositoryBase<t_KB_Tag>, ITagRepository
    {
        public TagRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }

    public interface ITagRepository : IRepositoryBase<t_KB_Tag>
    {

    }
}
