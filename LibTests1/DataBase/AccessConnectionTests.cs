using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.DataBase.Tests
{
    [TestClass()]
    public class AccessConnectionTests
    {
        [TestMethod()]
        public void AccessConnectionTest()
        {
            AccessConnection connection = new AccessConnection();
            connection.SetConnection(@"D:\project\cui\2019-12-15D(1).MDB");
            connection.OpenConnection();
            Assert.Fail();
        }
    }
}