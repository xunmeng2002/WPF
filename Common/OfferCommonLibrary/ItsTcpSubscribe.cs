using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCommonLibrary
{
    public class ItsTcpSubscribe : PropertyChangedNotify, ITcpSubscribe
    {
        public ItsTcpSubscribe(CommonLibrary.TcpIOCPServer tcpIOCPServer, MainWindow mainWindow)
        {
            TcpIOCPServer = tcpIOCPServer;
            m_MainWindow = mainWindow;
        }
        private MainWindow m_MainWindow;
        public CommonLibrary.TcpIOCPServer TcpIOCPServer { get; set; }
        public ObservableCollection<UserToken> m_Connects { get; set; } = new ObservableCollection<UserToken>();
        public void OnConnected(UserToken userToken)
        {
            m_Connects.Add(userToken);
        }

        public void OnDisconnected(UserToken userToken)
        {
            m_Connects.Remove(userToken);
        }

        public void OnRecv(UserToken userToken, byte[] msg, int offset, int len)
        {
            throw new NotImplementedException();
        }
    }
}
