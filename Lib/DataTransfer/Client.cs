﻿using Lib.DataBase;
using Lib.DataBase.Model;
using System;
using System.Configuration;
using System.Data;
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
                        accessConnection.RefreshData(processPattern);
                        accessConnection.process.SetProcessPattern(processPattern);
                        accessConnection.data.SetInformation(_clientName);
                        if (accessConnection.data.recordCount != 0)
                        {
                            byte[] sendMessageBytes = accessConnection.data.SendData();
                            clientSock.Send(sendMessageBytes);
                            System.Threading.Thread.Sleep(_interval * 1000);
                            try
                            {
                                byte[] messageBytes = new byte[100 * 1024];
                                clientSock.Receive(messageBytes);
                                string message = Encoding.UTF8.GetString(messageBytes);
                                ResponseMessage response = ResponseMessage.Deserialize(message);
                                if (response.Length == accessConnection.data.recordCount)
                                {
                                    accessConnection.ChangeTimeStamp();
                                }
                            }
                            catch (Exception e)
                            {
                                throw new Exception("未收到返回确认");
                            };
                        }
                        else 
                        {
                            System.Threading.Thread.Sleep(_interval * 1000);
                        }
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
