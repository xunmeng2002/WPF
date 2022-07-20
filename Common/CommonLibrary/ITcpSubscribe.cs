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
        public void OnDisconnected(long sessionID);
        public void OnRecv(long sessionID, byte[] msg, int offset, int len);
    }
}
