using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace Lib.DataTransfer
{
    public class Client
    {
        public bool StartToSend = false;
        Socket clientSock;
        Thread thread; 
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

        public void SetSend() 
        {
            StartToSend = !StartToSend;
        }

        public void Start() 
        {
            thread = new Thread(SendMessage);
            thread.Start();
            //ReceiveMessage();
        }

        public void End() 
        {
            Environment.Exit(0);
        }

        public void SendMessage() 
        {
            try
            {
                while (StartToSend)
                {
                    Console.WriteLine("客户端发送消息:");
                    clientSock.Send(Encoding.UTF8.GetBytes("Message from client"));
                    System.Threading.Thread.Sleep(1000);
                }
            }
            catch (Exception) 
            {
                throw new Exception("连接已断开");
            }
        }
    }
}
