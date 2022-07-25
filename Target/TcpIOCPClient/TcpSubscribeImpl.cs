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
        }
        private List<UserToken> m_Connects = new List<UserToken>();

        private CommonLibrary.TcpIOCPClient TcpIOCPClient { get; set; }
        public void OnConnected(UserToken userToken)
        {
            Console.WriteLine($"OnConnected SessionID:{userToken.SessionID}, IPEndPoint:{userToken.IPEndPoint}");
            lock (m_Connects)
            {
                m_Connects.Add(userToken);
            }
            if (TcpIOCPClient != null)
            {
                TcpIOCPClient.Send(userToken, "Hello World!");
            }
        }
        public void OnDisconnected(UserToken userToken)
        {
            Console.WriteLine($"OnDisconnected SessionID:{userToken.SessionID}");
            lock (m_Connects)
            {
                m_Connects.Remove(userToken);
            }
        }
        public void OnRecv(UserToken userToken, byte[] msg, int offset, int len)
        {
            string recvMsg = Encoding.UTF8.GetString(msg, offset, len);
            Console.WriteLine($"OnRecv {recvMsg}");
        }
        public void Close()
        {
            lock(m_Connects)
            {
                foreach (var item in m_Connects)
                {
                    TcpIOCPClient.Disconnect(item);
                }
            }
        }
    }
}
