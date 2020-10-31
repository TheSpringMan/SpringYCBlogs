using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SpringYCBlogs.Domain.Models;

namespace SpringYCBlogs.Infrastructure
{
    public class EFDbContext:DbContext
    {
        public EFDbContext() : base("name=SpringYCBlogs")
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
