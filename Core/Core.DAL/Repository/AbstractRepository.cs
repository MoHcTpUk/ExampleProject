using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DAL.Repository
{
    public abstract class AbstractRepository<TEntity> : IRepository<TEntity> where TEntity : AbstractEntity
    {
        private readonly DbContext _context;

        protected AbstractRepository(IDbContextFactory<DbContext> context)
        {
            _context = context.CreateDbContext();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(int id)
        {
            return _context.Set<TEntity>().Where(_ => _.Id == id);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = Get(id).FirstOrDefault();

            if (entity is null)
                return false;

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}