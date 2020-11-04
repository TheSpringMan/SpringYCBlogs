using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SpringYCBlogs.Domain;

namespace SpringYCBlogs.Infrastructure.Concrete
{
    public class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity: Domain.EntityBase<TPrimaryKey> where TPrimaryKey : struct
    {
        private readonly DbContext _dbContext;
        public RepositoryBase(DbContext context)
        {
            this._dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public DbContext DbContext => this._dbContext;

        public virtual void Delete(TEntity entity)
        {
            this._dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void Delete(TPrimaryKey id)
        {
            var entity = this._dbContext.Set<TEntity>().Find(id);
            if (entity != null)
            {
                this._dbContext.Set<TEntity>().Remove(entity);
            }
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            return this._dbContext.Set<TEntity>().Any(expression);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return this._dbContext.Set<TEntity>().FirstOrDefault(expression);
        }

        public virtual TEntity Get(TPrimaryKey id)
        {
            return this._dbContext.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(id));
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return this._dbContext.Set<TEntity>();
        }

        public virtual void Insert(TEntity entity)
        {
            this._dbContext.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            this._dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
