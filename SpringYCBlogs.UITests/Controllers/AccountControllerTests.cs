using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringYCBlogs.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SpringYCBlogs.UI.Infrastructure.Provider;
using SpringYCBlogs.Domain.Models;
using SpringYCBlogs.Service;

namespace SpringYCBlogs.UI.Controllers.Tests
{
    [TestClass()]
    public class AccountControllerTests
    {
        [TestMethod()]
        public void RegisterTest()
        {
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            var accountMock = new Mock<IAccountService>();

        }
    }
}