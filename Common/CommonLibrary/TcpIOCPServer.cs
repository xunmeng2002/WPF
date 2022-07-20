using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class TcpIOCPServer : TcpIOCP, ITcpServer
    {
        public TcpIOCPServer(int numConnections, int receiveBufferSize)
            :base(numConnections, receiveBufferSize)
        {
            
        }

        public void Start(IPEndPoint ipEndPoint)
        {
            m_IPEndPoint = ipEndPoint;
            m_ListenSocket = new Socket(m_IPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            m_ListenSocket.Bind(m_IPEndPoint);
            m_ListenSocket.Listen(m_NumConnections);

            for (int i = 0; i < m_NumConnections; i++)
            {
                PostAccept(null);
            }
        }
    }
}
