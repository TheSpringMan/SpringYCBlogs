using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringYCBlogs.Domain
{
    public class EntityBase<TPrimaryKey> where TPrimaryKey:struct
    {
        public EntityBase()
        {
            this.CreateTime = DateTime.Now;
            this.IsActived = true;
        }
        public TPrimaryKey Id { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsActived { get; set; }
    }
}
