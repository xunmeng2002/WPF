using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public interface ITcpServer : ITcp
    {
        void Start(IPEndPoint ipEndPoint);
    }
}
