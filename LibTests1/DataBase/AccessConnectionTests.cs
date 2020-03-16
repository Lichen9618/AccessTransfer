using Lib.DataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lib.DataBase.Tests
{
    [TestClass()]
    public class AccessConnectionTests
    {
        [TestMethod()]
        public void AccessConnectionTest()
        {
        }

        [TestMethod()]
        public void ChangeTimeStampTest()
        {
            AccessConnection accessConnection = new AccessConnection("D:\\project\\cui\\code\\AccessTransfer\\AccessTransferClient\\bin\\Debug\\AccessTransferClient.exe");
            accessConnection.SetConnection("D:\\project\\cui\\2019-12-15D.MDB");
            accessConnection.OpenConnection();
            accessConnection.RefreshData();
            accessConnection.ChangeTimeStamp();           
        }
    }
}