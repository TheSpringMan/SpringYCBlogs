using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringYCBlogs.Domain.Models
{
    public class Article:EntityBase<Guid>
    {
        public Article()
        {
            this.Id = Guid.NewGuid();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public int GoodCount { get; set; }

        public virtual User User { get; set; }
    }
}
