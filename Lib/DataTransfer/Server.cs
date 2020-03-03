using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Lib.DataTransfer
{
    class Server
    {
        Socket serverSock;
        List<Socket> clientList = new List<Socket>();

        public Server(string ip, int port)
        {
            //IPv4的地址模式. 流式数据传输
            serverSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress iPAddress;

            if (!IPAddress.TryParse(ip, out iPAddress)) 
            {
                throw new Exception("Ip地址格式错误");
            }
            IPEndPoint point = new IPEndPoint(iPAddress, port);
            serverSock.Bind(point);
            serverSock.Listen(0);
        }

        public void AcceptClient() 
        {
            while (true) 
            {
                Socket client = serverSock.Accept();
                IPEndPoint endPoint = client.RemoteEndPoint as IPEndPoint;
                clientList.Add(client);
                Thread tempClient = new Thread(ReceiveMessage);
                tempClient.Start(client);
            }
        }

        public void ReceiveMessage(object Message) 
        {
            while (true) 
            {
                Socket client = Message as Socket;
                byte[] messageBytes = new byte[100 * 1024];
                try
                {
                    int num = client.Receive(messageBytes);
                    IPEndPoint clientPoint = client.RemoteEndPoint as IPEndPoint;
                    //对messageBytes进行进一步处理
                }
                catch (Exception e) 
                {
                    clientList.Remove(client);
                    break;
                }
            }
        }

        public void Start() 
        {
            Thread thread = new Thread(AcceptClient);
            thread.Start();

        }
    }
}
