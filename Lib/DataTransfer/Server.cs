using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Lib.DataBase;
using Lib.DataBase.Model;

namespace Lib.DataTransfer
{
    public class Server
    {
        private IPAddress _ipAddress;
        private int _port;
        private Thread acceptThread;

        string TransferMessage;
        string ConnectionMessage;
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
        public Server()
        {
            //IPv4的地址模式. 流式数据传输
            if (!int.TryParse(ConfigurationManager.AppSettings["Port"], out _port))
            {
                throw new Exception("端口配置错误");
            }
            if (!IPAddress.TryParse(ConfigurationManager.AppSettings["IpAddress"], out _ipAddress))
            {
                throw new Exception("Ip地址格式错误");
            }
            serverSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint point = new IPEndPoint(_ipAddress, _port);
            serverSock.Bind(point);
            serverSock.Listen(0);
        }

        public void AcceptClient()
        {
            while (connect)
            {
                Socket client = serverSock.Accept();
                clientList.Add(client);
                Thread tempClient = new Thread(ReceiveMessage);
                tempClient.Start(client);
            }
        }

        public void ReceiveMessage(object Message)
        {
            while (receiveMessage)
            {
                Socket client = Message as Socket;
                byte[] messageBytes = new byte[1024 * 1024];
                try
                {
                    int num = client.Receive(messageBytes);
                    if (num != 0)
                    {
                        string message = Encoding.UTF8.GetString(messageBytes);
                        DataWrapper wrapper = DataWrapper.Deserialize(message);
                        SqlServerConnection.WriteDataToDB(wrapper);
                        AnalysisMessgae(wrapper);
                        ResponseMessage response = new ResponseMessage(wrapper.recordCount);
                        client.Send(response.SendData());
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
        private void AnalysisMessgae(DataWrapper wrapper) 
        {
            TransferMessage =
                "收到来自: " + wrapper.clientName +
                //"\r\nAlarmInfo: " + wrapper._AlarmInfo.Rows.Count +
                "\r\n开关量存盘记录: " + wrapper._onOffRecord.Rows.Count +
                "\r\n温湿度数据:" + wrapper._tmpAndMoistData.Rows.Count;
        }       

        public string CheckConnection() 
        {
            string result = "";
            if (clientList.Count == 0) 
            {
                return result;
            }
            if (clientList.Count == 1)
            {
                return clientList[0].RemoteEndPoint.ToString();
            }
            else 
            {
                foreach (var client in clientList)
                {
                    try
                    {
                        client.Send(new byte[] { 0x00 });
                        result += client.RemoteEndPoint.ToString();
                    }
                    catch (SocketException e)
                    {
                        clientList.Remove(client);
                    }
                }
                return result;
            }
        }

        public string ShowMessage()
        {            
            string result = TransferMessage;
            TransferMessage = "";
            return result;
        }

        public bool ShowConnectionMessage(out string result)
        {
            if (ConnectionMessage == "")
            {
                result = "";
                return false;
            }
            else 
            {
                result = ConnectionMessage;
                ConnectionMessage = "";
                return true;
            }
        }

        public void Start()
        {
            acceptThread = new Thread(AcceptClient);
            acceptThread.Start();
        }

        public void Stop() 
        {
            if (connect) 
            {
                SetConnect();
            }
            if (receiveMessage) 
            {
                SetReceiveMessage();
            }
            serverSock.Close();
            foreach (var client in clientList) 
            {
                client.Close();
            }
        }
    }
}
