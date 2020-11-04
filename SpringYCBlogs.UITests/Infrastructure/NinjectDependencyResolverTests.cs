using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringYCBlogs.Infrastructure;
using SpringYCBlogs.Infrastructure.Repository;
using SpringYCBlogs.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringYCBlogs.UI.Infrastructure.Tests
{
    [TestClass()]
    public class NinjectDependencyResolverTests
    {
        [TestMethod()]
        public void NinjectDependencyResolverTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void GetServiceTest()
        {
            NinjectDependencyResolver resolver = new NinjectDependencyResolver();
            var unitOfWork = resolver.GetService(typeof(IUserRepository));
            Assert.IsInstanceOfType(unitOfWork, typeof(IUserRepository));
        }

        [TestMethod()]
        public void DbContextIsSingleton()
        {
            var context = new EFDbContext();
            var role1 = new RoleRepository(context);
            var user1 = new UserRepository(context);
            Assert.IsTrue(role1.DbContext == user1.DbContext);
            //var role = (IRoleRepository)NinjectDependencyResolver.Instance.GetService(typeof(IRoleRepository));
            //var user = (IUserRepository)NinjectDependencyResolver.Instance.GetService(typeof(IUserRepository));
            //Assert.IsTrue(role.DbContext == user.DbContext);
        }

    }
}