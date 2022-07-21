using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCommonLibrary
{
    public class TcpSubscribe : ITcpSubscribe
    {
        public TcpSubscribe(CommonLibrary.TcpIOCPServer tcpIOCPServer)
        {
            TcpIOCPServer = tcpIOCPServer;
        }
        public CommonLibrary.TcpIOCPServer TcpIOCPServer { get; set; }

        public void OnConnected(long sessionID)
        {
            throw new NotImplementedException();
        }

        public void OnDisconnected(long sessionID)
        {
            throw new NotImplementedException();
        }

        public void OnRecv(long sessionID, byte[] msg, int offset, int len)
        {
            throw new NotImplementedException();
        }
    }
}
