using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringYCBlogs.Infrastructure.Abstract
{
    public interface IEntity<TPrimaryKey> where TPrimaryKey:struct
    {
        TPrimaryKey Id { get; set; }
    }

    public interface IEntity : IEntity<int>
    {

    }
}
