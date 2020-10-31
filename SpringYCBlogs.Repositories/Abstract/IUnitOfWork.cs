using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SpringYCBlogs.Infrastructure.Abstract
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
