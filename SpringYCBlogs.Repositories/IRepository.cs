using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace SpringYCBlogs.Infrastructure
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity: Domain.EntityBase<TPrimaryKey> where TPrimaryKey:struct
    {
        DbContext DbContext { get; }
        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(TPrimaryKey id);

        IQueryable<TEntity> GetAll();

        TEntity Get(TPrimaryKey id);

        bool Exists(Expression<Func<TEntity, bool>> expression);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression);
    }

}
