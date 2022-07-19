using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpIOCPServer
{
    public class TcpSubscribeImpl : TcpSubscribe
    {
        public TcpSubscribeImpl(TcpIOCPServer tcpIOCPServer)
        {
            TcpIOCPServer = tcpIOCPServer;
        }

        private TcpIOCPServer TcpIOCPServer { get; set; }
        public void OnConnected(int sessionID)
        {
            Console.WriteLine($"OnConnected SessionID:{sessionID}");
        }

        public void OnDisconnected(int sessionID)
        {
            Console.WriteLine($"OnDisconnected SessionID:{sessionID}");
        }

        public void OnRecv(int sessionID, byte[] msg, int offset, int len)
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
