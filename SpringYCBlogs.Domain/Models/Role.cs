using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringYCBlogs.Domain.Models
{
    public class Role:EntityBase<Int32>
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
