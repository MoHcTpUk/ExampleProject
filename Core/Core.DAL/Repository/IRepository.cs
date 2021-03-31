using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DAL.Entities;

namespace Core.DAL.Repository
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        public IQueryable<TEntity> GetAll();
        public IQueryable<TEntity> Get(int id);
        public IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate);
        public Task<TEntity> Create(TEntity item);
        public Task<TEntity> Update(TEntity item);
        public Task<bool> Delete(int id);
    }
}