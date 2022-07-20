using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public interface ITcp
    {
        public void Init();
        public void RegisterSubscribe(ITcpSubscribe tcpSubscribe);
        public bool Send(long sessionID, byte[] msg, int offset, int len);
        public bool Send(long sessionID, string msg);
    }
}
