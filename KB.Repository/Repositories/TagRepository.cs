using KB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Repository.Repositories
{
    public class TagRepository : RepositoryBase<t_KB_Tag>, ITagRepository
    {
        public TagRepository(KBDataContext dbContext) : base(dbContext)
        {
        }
    }

    public interface ITagRepository : IRepositoryBase<t_KB_Tag>
    {

    }
}
