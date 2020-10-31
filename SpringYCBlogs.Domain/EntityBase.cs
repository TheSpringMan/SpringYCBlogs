using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringYCBlogs.Domain
{
    public class EntityBase
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
            IsActived = true;
        }
        public Guid Id { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsActived { get; set; }
    }
}
