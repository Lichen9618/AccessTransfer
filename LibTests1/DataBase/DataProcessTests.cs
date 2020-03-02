using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.DataBase.Tests
{
    [TestClass()]
    public class DataProcessTests
    {
        [TestMethod()]
        public void DataProcessTest()
        {
            DataProcess dataProcess = new DataProcess("test");
        }
    }
}