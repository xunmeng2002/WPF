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
        public void OnConnected(UserToken userToken)
        {
            Console.WriteLine($"OnConnected SessionID:{userToken.SessionID}, IPEndPoint:{userToken.IPEndPoint}");
        }

        public void OnDisconnected(UserToken userToken)
        {
            Console.WriteLine($"OnDisconnected SessionID:{userToken.SessionID}");
        }

        public void OnRecv(UserToken userToken, byte[] msg, int offset, int len)
        {
            string recvMsg = Encoding.UTF8.GetString(msg, offset, len);
            Console.WriteLine($"OnRecv {recvMsg}");
            if (TcpIOCPServer != null)
            {
                TcpIOCPServer.Send(userToken, "Server Response:" + recvMsg);
            }
        }
    }
}
