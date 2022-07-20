using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            m_Connects = new List<long>();
        }
        private List<long> m_Connects;

        private CommonLibrary.TcpIOCPClient TcpIOCPClient { get; set; }
        public void OnConnected(long sessionID, IPEndPoint ipEndPoint)
        {
            Console.WriteLine($"OnConnected SessionID:{sessionID}, IPEndPoint:{ipEndPoint}");
            lock (m_Connects)
            {
                m_Connects.Add(sessionID);
            }
            if (TcpIOCPClient != null)
            {
                TcpIOCPClient.Send(sessionID, "Hello World!");
            }
        }
        public void OnDisconnected(long sessionID)
        {
            Console.WriteLine($"OnDisconnected SessionID:{sessionID}");
            lock (m_Connects)
            {
                m_Connects.Remove(sessionID);
            }
        }
        public void OnRecv(long sessionID, byte[] msg, int offset, int len)
        {
            string recvMsg = Encoding.UTF8.GetString(msg, offset, len);
            Console.WriteLine($"OnRecv {recvMsg}");
        }
        public void Close()
        {
            lock(m_Connects)
            {
                foreach (var sessionID in m_Connects)
                {
                    TcpIOCPClient.Disconnect(sessionID);
                }
            }
        }
    }
}
