using afmr.data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.data.Repos
{
    public class RepoBase<TEntity> where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        public RepoBase(MarketResearchDbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Get()
        {
            return _dbSet.AsNoTracking();
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if(null != entity)
            {
                Delete(entity);
            }
        }
    }
}
