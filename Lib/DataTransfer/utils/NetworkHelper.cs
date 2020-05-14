using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace Lib.DataTransfer.utils
{
    public sealed class NetworkHelper
    {
        private static NetworkHelper instance = null;
        private static readonly object padlock = new object();
        private Ping ping = new Ping();
        private IPAddress ipAddress;
        private int timeOut;
        private IPEndPoint port;
        public string status;


        public static NetworkHelper GetInstance()
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new NetworkHelper();
                    }
                }
            }
            return instance;
        }

        private NetworkHelper() { }

        public bool setParameters(IPAddress iPAddress, int TimeOut, int Port)
        {
            if (instance != null)
            {
                ipAddress = iPAddress;
                timeOut = TimeOut;
                port = new IPEndPoint(ipAddress, Port);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IfConnected()
        {
            status = "";
            PingReply reply = ping.Send(ipAddress, timeOut);
            if (reply.Status == IPStatus.Success)
            {
                status += "服务器在线;";
                return IfIpEndPointOnline();

            }
            else 
            {
                status += "服务器已关闭";
            }
            return false;
        }

        private bool IfIpEndPointOnline() 
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(port);
                status += "服务端程序在线";
                return true;
            }
            catch (Exception e)
            {
                status += "服务端程序未打开;" + e.ToString();
                return false;
            }
        }
    }
}
