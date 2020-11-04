namespace SpringYCBlogs.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SpringYCBlogs.Domain.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SpringYCBlogs.Infrastructure.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SpringYCBlogs.Infrastructure.EFDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //var roles = new Role[]
            //{
            //    new Role{Id =1, RoleName="Admin" },
            //    new Role{RoleName="User"},
            //    new Role{RoleName="Manager"}
            //};
            //context.Roles.AddRange(roles);

            //var users = new User[]
            //{
            //    new User{ Id=1, UserName="张三", Email="ZhangSan@qq.com", DateOfBirth=DateTime.Now.AddYears(-18)},
            //    new User{ Id=2,UserName="李四", Email="LiSi@qq.com", DateOfBirth=DateTime.Now.AddYears(-18)},
            //    new User{ Id=3,UserName="王五", Email="WangWu@qq.com", DateOfBirth=DateTime.Now.AddYears(-18)}
            //};
            //context.Users.AddRange(users);

            //base.Seed(context);
        }
    }
}
