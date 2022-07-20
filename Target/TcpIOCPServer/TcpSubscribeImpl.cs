using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary;

namespace TcpIOCPServer
{
    public class TcpSubscribeImpl : ITcpSubscribe
    {
        public TcpSubscribeImpl(CommonLibrary.TcpIOCPServer tcpIOCPServer)
        {
            TcpIOCPServer = tcpIOCPServer;
        }

        private CommonLibrary.TcpIOCPServer TcpIOCPServer { get; set; }
        public void OnConnected(long sessionID, IPEndPoint ipEndPoint)
        {
            Console.WriteLine($"OnConnected SessionID:{sessionID}, IPEndPoint:{ipEndPoint}");
        }

        public void OnDisconnected(long sessionID)
        {
            Console.WriteLine($"OnDisconnected SessionID:{sessionID}");
        }

        public void OnRecv(long sessionID, byte[] msg, int offset, int len)
        {
            string recvMsg = Encoding.UTF8.GetString(msg, offset, len);
            Console.WriteLine($"OnRecv {recvMsg}");
            if (TcpIOCPServer != null)
            {
                TcpIOCPServer.Send(sessionID, "Server Response:" + recvMsg);
            }
        }
    }
}
