using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringYCBlogs.UI.Infrastructure.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SpringYCBlogs.Service;
using SpringYCBlogs.Domain.Models;

namespace SpringYCBlogs.UI.Infrastructure.Provider.Tests
{
    [TestClass()]
    public class FormsAuthProviderTests
    {
        [TestMethod()]
        public void CreateUserTest()
        {
            var accountMock = new Mock<IAccountService>();
            accountMock.Setup(x => x.AddUser(new User { UserName = "张三", Password = "123456" })).Verifiable();
            var auth = new FormsAuthProvider();
            Assert.IsTrue(auth.CreateUser("张三", "", "123456"));
        }
    }
}