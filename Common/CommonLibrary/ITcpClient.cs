using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public interface ITcpClient : ITcp
    {
        public void Connect(IPEndPoint ipEndPoint);
        public void Disconnect(long sessionID);
    }
}
