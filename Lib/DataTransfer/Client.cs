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
    class Client
    {
        Socket clientSock;
        public Client(string ip, int port) 
        {
            clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                IPEndPoint point = new IPEndPoint(IPAddress.Parse(ip), port);
                clientSock.Connect(point);
            }
            catch (Exception)
            {
                throw new Exception("IP地址配置错误");
            }        
        }

        public void Start() 
        {
            Thread thread = new Thread(SendMessage);
            thread.Start();
            ReceiveMessage();
        }

        public void SendMessage() 
        {
            try
            {
                while (true)
                {
                    clientSock.Send(Encoding.Default.GetBytes("TestMessage"));
                }
            }
            catch (Exception) 
            {
                throw new Exception("连接已断开");
            }
        }

        public void ReceiveMessage() 
        {
            try
            {
                while (true)
                {
                    byte[] messageBytes = new byte[100 * 1024];
                    int num = clientSock.Receive(messageBytes);

                }
            }
            catch (Exception) 
            {
                throw new Exception("服务器断开");
            }
        }
    }
}
