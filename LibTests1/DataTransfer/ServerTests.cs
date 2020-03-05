using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.DataTransfer.Tests
{
    [TestClass()]
    public class ServerTests
    {
        [TestMethod()]
        public void ServerTest()
        {
            Server server = new Server("127.0.0.1", 8888);
            server.Start();

            Client client = new Client("127.0.0.1", 8888);
            client.Start();
        }
    }
}