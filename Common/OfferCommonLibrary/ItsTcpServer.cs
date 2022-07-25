using CommonLibrary;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OfferCommonLibrary
{
    public class ItsTcpServer
    {
        public ItsTcpServer(ILogger<ItsTcpServer> logger, BaseConfig baseConfig)
        {
            Logger = logger;
            BaseConfig = baseConfig;
            TcpIOCPServer = new TcpIOCPServer();
        }
        private ILogger<ItsTcpServer> Logger { get; set; }
        private BaseConfig BaseConfig { get; set; }
        private TcpIOCPServer TcpIOCPServer { get; set; }

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
