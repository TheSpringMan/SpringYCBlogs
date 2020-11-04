using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SpringYCBlogs.Infrastructure.Concrete
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public int Commit()
        {
            return this._dbContext.SaveChanges();
        }
    }
}
