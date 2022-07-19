using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class AsyncUserToken
    {
        public AsyncUserToken(int sessionID, Socket socket)
        {
            SessionID = sessionID;
            Socket = socket;
        }
        public int SessionID { get; set; }
        public Socket Socket { get; set; }
    }
}
