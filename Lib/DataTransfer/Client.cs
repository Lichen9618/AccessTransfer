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
                throw new Exception("Socket连接错误");
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

        public bool SetDataPickInterval(int interval = 3)
        {
            this._interval = interval;
            return true;
        }
    }
}
