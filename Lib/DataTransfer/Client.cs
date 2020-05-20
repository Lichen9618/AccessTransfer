using Lib.DataBase;
using Lib.DataBase.Model;
using Lib.DataTransfer.utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace Lib.DataTransfer
{
    public sealed class Client
    {
        private static Client instance = null;
        private static readonly object padlock = new object();
        private IPAddress _ipAddress;
        private int _port;
        private int _interval;
        private string _clientName;
        private List<string> _currentState = new List<string>();
        

        public ProcessPattern processPattern;
        public AccessConnection accessConnection;
        public DataProcess dataProcess;
        public bool ServerConntected = false;
        public bool StartToSend = false;
        public NetworkHelper networkHelper;
        Socket clientSock;
        Thread thread;

        public static Client GetInstance()
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Client();
                    }
                }
            }
            return instance;
        }

        public Client()
        {
            ConnectServer();
            networkHelper = NetworkHelper.GetInstance();
            networkHelper.setParameters(_ipAddress, 200, _port);
        }

        public string ConnectServer()
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
                ServerConntected = true;
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "连接成功";
        }

        public string ReconnectServer(bool isRun) 
        {
            if (ServerConntected == false) 
            {
                if (networkHelper.IfConnected())
                {
                    ConnectServer();
                    if (isRun) Start();
                }
            }
            else
            {
                return "连接未断开, 无需重连";
            }
            return networkHelper.status;
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
            thread = new Thread(SendMessage);
            thread.Start();
            //ReceiveMessage();
        }

        public void End()
        {
            StartToSend = false;
        }

        public void SendMessage()
        {
            if (accessConnection.IsConnected)
            {
                try
                {
                    while (StartToSend)
                    {
                        accessConnection.RefreshData(processPattern);
                        //accessConnection.process.SetProcessPattern(processPattern);
                        accessConnection.data.SetInformation(_clientName);
                        if (accessConnection.data.recordCount != 0)
                        {
                            try
                            {
                                byte[] sendMessageBytes = accessConnection.data.SendData();
                                clientSock.Send(sendMessageBytes);
                                for (int i = 0; i < 3; i++)
                                {
                                    System.Threading.Thread.Sleep(_interval * 1000);
                                    try
                                    {
                                        byte[] messageBytes = new byte[100 * 1024];
                                        clientSock.Receive(messageBytes);
                                        string message = Encoding.UTF8.GetString(messageBytes);
                                        ResponseMessage response = ResponseMessage.Deserialize(message);
                                        if (response.Length == accessConnection.data.recordCount)
                                        {
                                            _currentState.Add(response.Time.ToString() + "|成功发送消息");
                                            accessConnection.ChangeTimeStamp();
                                            break;
                                        }
                                    }
                                    catch
                                    {
                                        if (i == 3)
                                        {
                                            _currentState.Add("发送失败超过3次, 主动与服务端断开连接");
                                            throw new Exception("未收到返回确认");
                                        }
                                        else
                                        {
                                            _currentState.Add(DateTime.Now.ToString() + "|发送消息失败, 进行第" + (i + 1).ToString() + "次重试");
                                            continue;
                                        }
                                    };
                                }
                            }
                            catch (Exception e)
                            {
                                _currentState.Add("服务端断连,请检查");
                                ServerConntected = false;
                                StartToSend = false;
                            }
                        }
                        else
                        {
                            System.Threading.Thread.Sleep(_interval * 1000);
                        }
                    }
                }
                catch
                {
                    _currentState.Add("数据库读取出错,请检查");
                    StartToSend = false;
                }
            }
            else
            {
                throw new Exception("数据库连接断开");
            }
        }

        public bool CheckConnection() 
        {
            try
            {
                clientSock.Send(new byte[] { 0x00 });
                return true;
            }
            catch 
            {
                ServerConntected = false;
                return false;
            }
            
        }

        public bool SetDataPickInterval(int interval = 3)
        {
            this._interval = interval;
            return true;
        }

        public List<string> showMessage() 
        {
            List<string> result = _currentState;
            _currentState = new List<string>();
            return result;
        }
    }
}
