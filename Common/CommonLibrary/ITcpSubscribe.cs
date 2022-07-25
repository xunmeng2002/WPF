using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public interface ITcpSubscribe
    {
        public void OnConnected(UserToken userToken);
        public void OnDisconnected(UserToken userToken);
        public void OnRecv(UserToken userToken, byte[] msg, int offset, int len);
    }
}
