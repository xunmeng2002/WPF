using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonLibrary;

namespace OfferCommon
{
    public class TcpServer
    {
        public TcpServer(BaseConfig baseConfig)
        {
            BaseConfig = baseConfig;
            TcpIOCPServer = new TcpIOCPServer();
        }
        private BaseConfig BaseConfig { get; }
        private TcpIOCPServer TcpIOCPServer { get; set; }
        private int ShouldRun;
        public void Init()
        {
            TcpIOCPServer.Init();
        }
        public void Start()
        {
            TcpIOCPServer.Start(new IPEndPoint(IPAddress.Any, BaseConfig.ListenPort));
        }
    }
}
