using Lib.DataBase;
using Lib.DataBase.Model;
using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace Lib.DataTransfer
{
    public class Client
    {
        private IPAddress _ipAddress;
        private int _port;
        private int _interval;
        private string _clientName;

        public ProcessPattern processPattern;
        public AccessConnection accessConnection;
        public DataProcess dataProcess;
        public bool StartToSend = false;
        Socket clientSock;
        Thread thread;
        public Client()
        {
            if (!int.TryParse(ConfigurationManager.AppSettings["Port"], out _port))
            {
                throw new Exception("端口配置错误");
            }
            if (!IPAddress.TryParse(ConfigurationManager.AppSettings["IpAddress"], out _ipAddress))
            {
                throw new Exception("IP地址配置错误");
            }
            _clientName = ConfigurationManager.AppSettings["ClientName"];

            clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                IPEndPoint point = new IPEndPoint(_ipAddress, _port);
                clientSock.Connect(point);
            }
            catch (Exception)
            {
                throw new Exception("服务端已断开");
            }
        }

        public bool SetAcceesConnection(AccessConnection connection) 
        {
            this.accessConnection = connection;
            return true;
        }

        public void SetSend()
        {
            StartToSend = !StartToSend;
        }

        public void Start()
        {
            dataProcess = new DataProcess(processPattern);
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
            if (accessConnection.IsConnected)
            {
                try
                {
                    while (StartToSend)
                    {
                        //开始写dataprocess返回处理好的数据, 并在dataprocess中, 加入序列化的部分
                        string message = "Message from client: " + _clientName;
                        clientSock.Send(Encoding.UTF8.GetBytes(message));
                        System.Threading.Thread.Sleep(_interval * 1000);
                    }
                }
                catch (Exception)
                {
                    throw new Exception("连接已断开");
                }
            }
            else 
            {
                throw new Exception("数据库连接断开");
            }

        }

        public void SendTestMessage() 
        {
            try
            {
                while (StartToSend) 
                {
                    string message = "Message from client: " + _clientName;
                    clientSock.Send(Encoding.UTF8.GetBytes(message));
                    System.Threading.Thread.Sleep(_interval * 1000);
                }
            }
            catch
            {
                throw new Exception("连接已断开");
            }
        }



        public bool SetDataPickInterval(int interval = 3)
        {
            this._interval = interval;
            return true;
        }
    }
}
