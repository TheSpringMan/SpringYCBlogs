using System;
using System.Collections.Generic;

namespace SpringYCBlogs.Domain.Models
{
    public class User:EntityBase<Int32>
    {
        public User()
        {
            this.Articles = new HashSet<Article>();
            this.Roles = new HashSet<Role>();
        }
        public string UserName { get; set; }

        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string Email { get; set; }

        public bool? Gender { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
