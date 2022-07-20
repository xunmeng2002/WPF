using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class TcpIOCPClient : TcpIOCP, ITcpClient
    {
        public TcpIOCPClient(int numConnections, int receiveBufferSize)
            : base(numConnections, receiveBufferSize)
        {

        }
        public void Connect(IPEndPoint ipEndPoint)
        {
            PostConnect(ipEndPoint);
        }
    }
}
