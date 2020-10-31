using System;
using System.Linq;
using System.Linq.Expressions;

namespace SpringYCBlogs.Infrastructure.Abstract
{
    public interface IRepository<TEntity> where TEntity: Domain.EntityBase
    {
        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(Guid id);

        IQueryable<TEntity> GetAll();

        TEntity Get(Guid id);

        bool Exists(Expression<Func<TEntity, bool>> expression);
    }

}
