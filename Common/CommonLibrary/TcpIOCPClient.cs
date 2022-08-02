using Microsoft.Extensions.Logging;
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
        public TcpIOCPClient(ILogger logger, int numConnections = 10, int receiveBufferSize = 64 * 1024)
            : base(logger, numConnections, receiveBufferSize)
        {

        }
        public void Connect(IPEndPoint ipEndPoint)
        {
            PostConnect(ipEndPoint);
        }

        public void Disconnect(UserToken userToken)
        {
            PostDisconnect(userToken);
        }
    }
}
