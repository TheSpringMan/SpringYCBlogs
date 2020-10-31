using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpringYCBlogs.Domain.Models;

namespace SpringYCBlogs.Infrastructure.Repository
{
    public class UserRepository : Concrete.EFRepository<User>
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}
