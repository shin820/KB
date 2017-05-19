﻿using System.Linq;
using System.Threading.Tasks;

namespace KB.Domain.Repositories
{
    public interface IRepositoryBase<TEntity>
    {
        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
        TEntity Find(int id);
        IQueryable<TEntity> FindAll();
        void Insert(TEntity entity);
        Task InsertAsync(TEntity entity);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}