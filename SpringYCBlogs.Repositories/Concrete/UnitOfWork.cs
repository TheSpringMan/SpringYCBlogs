using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SpringYCBlogs.Infrastructure.Abstract;

namespace SpringYCBlogs.Infrastructure.Concrete
{
    public class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public UnitOfWork(TDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public int Commit()
        {
            return this._dbContext.SaveChanges();
        }
    }
}
