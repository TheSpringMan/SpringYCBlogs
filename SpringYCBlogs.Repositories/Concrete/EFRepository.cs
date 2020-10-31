using SpringYCBlogs.Infrastructure.Abstract;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SpringYCBlogs.Infrastructure.Concrete
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity: Domain.EntityBase
    {
        private readonly DbContext _dbContext;
        public EFRepository(DbContext context)
        {
            this._dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public virtual void Delete(TEntity entity)
        {
            this._dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void Delete(Guid id)
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

        public virtual TEntity Get(Guid id)
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
