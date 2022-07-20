using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public interface ITcpSubscribe
    {
        void OnConnected(long sessionID);
        void OnDisconnected(long sessionID);
        void OnRecv(long sessionID, byte[] msg, int offset, int len);
    }
}
