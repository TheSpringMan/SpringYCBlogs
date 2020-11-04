using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringYCBlogs.UI.Infrastructure.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringYCBlogs.UI.Infrastructure.Provider.Tests
{
    [TestClass()]
    public class CustomMembershipProviderTests
    {
        [TestMethod()]
        public void GetUserNameByEmailTest()
        {
            //如果email对应的账户不存在，会返回什么？
            Assert.Fail();
        }
    }
}