using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Lib.DataTransfer
{
    public class Server
    {
        string message;
        public bool connect = false;
        public bool receiveMessage = false;
        Socket serverSock;
        List<Socket> clientList = new List<Socket>();

        public void SetConnect() 
        {
            connect = !connect;
        }
        public void SetReceiveMessage() 
        {
            receiveMessage = !receiveMessage;
        }
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
            while (connect) 
            {
                Socket client = serverSock.Accept();
                IPEndPoint endPoint = client.RemoteEndPoint as IPEndPoint;
                clientList.Add(client);
                Thread tempClient = new Thread(ReceiveMessage);
                tempClient.Start(client);
                Console.WriteLine("客户端连接,当前数量为 {0}", clientList.Count);
            }
        }

        public void ReceiveMessage(object Message) 
        {
            while (receiveMessage) 
            {
                Socket client = Message as Socket;
                byte[] messageBytes = new byte[100];
                try
                {
                    int num = client.Receive(messageBytes);
                    if (num != 0) 
                    {
                        message = Encoding.UTF8.GetString(messageBytes);
                    }
                    
                    IPEndPoint clientPoint = client.RemoteEndPoint as IPEndPoint;
                    //对messageBytes进行进一步处理
                    
                }
                catch
                {
                    clientList.Remove(client);
                    break;
                }
            }
        }

        public string ShowMessage() 
        {
            string result = message;
            message = "";
            return result;
        }

        public void Start() 
        {
            Thread thread = new Thread(AcceptClient);
            thread.Start();
        }
    }
}
