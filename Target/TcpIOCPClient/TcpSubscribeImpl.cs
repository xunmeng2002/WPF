using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary;

namespace TcpIOCPClient
{
    public class TcpSubscribeImpl : ITcpSubscribe
    {
        public TcpSubscribeImpl(CommonLibrary.TcpIOCPClient tcpIOCPClient)
        {
            TcpIOCPClient = tcpIOCPClient;
        }

        private CommonLibrary.TcpIOCPClient TcpIOCPClient { get; set; }
        public void OnConnected(long sessionID)
        {
            Console.WriteLine($"OnConnected SessionID:{sessionID}");
            if (TcpIOCPClient != null)
            {
                TcpIOCPClient.Send(sessionID, "Hello World!");
            }
        }

        public void OnDisconnected(long sessionID)
        {
            Console.WriteLine($"OnDisconnected SessionID:{sessionID}");
        }

        public void OnRecv(long sessionID, byte[] msg, int offset, int len)
        {
            string recvMsg = Encoding.UTF8.GetString(msg, offset, len);
            Console.WriteLine($"OnRecv {recvMsg}");
        }
    }
}
