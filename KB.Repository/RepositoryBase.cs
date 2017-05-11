using KB.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected KBEntities _dbContext;
        protected IDbSet<TEntity> DataSet;
        public RepositoryBase(KBEntities dbContext)
        {
            DataSet = dbContext.Set<TEntity>();
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> FindAll()
        {
            return DataSet;
        }

        public TEntity Find(int id)
        {
            return DataSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            DataSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task InsertAsync(TEntity entity)
        {
            DataSet.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            DataSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            DataSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
