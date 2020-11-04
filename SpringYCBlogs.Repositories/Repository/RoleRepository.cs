using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringYCBlogs.Infrastructure.Repository
{

    public interface IRoleRepository:IRepository<Domain.Models.Role, Int32>
    {

    }
    public class RoleRepository : Concrete.RepositoryBase<Domain.Models.Role, Int32>, IRoleRepository
    {
        public RoleRepository(DbContext context) : base(context)
        {
        }
    }

}
