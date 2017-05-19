using KB.Domain.Entities;
using System.Data.Entity;

namespace KB.Domain.Repositories
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
