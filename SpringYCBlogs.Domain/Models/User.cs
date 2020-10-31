using System;

namespace SpringYCBlogs.Domain.Models
{
    public class User:EntityBase
    {
        public string UserName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Email { get; set; }

        public bool? Gender { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Description { get; set; }
    }
}
