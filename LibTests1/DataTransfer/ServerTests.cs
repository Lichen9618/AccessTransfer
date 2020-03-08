using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.DataTransfer.Tests
{
    [TestClass()]
    public class ServerTests
    {
        [TestMethod()]
        public void ServerTest()
        {
            Server server = new Server();
            server.Start();

            Client client = new Client();
            client.Start();
        }
    }
}