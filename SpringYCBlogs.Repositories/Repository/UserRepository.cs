using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpringYCBlogs.Domain.Models;

namespace SpringYCBlogs.Infrastructure.Repository
{
    public interface IUserRepository : IRepository<Domain.Models.User, Int32>
    {

    }
    public class UserRepository : Concrete.RepositoryBase<User, Int32>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }

    
}
