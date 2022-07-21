using CommonLibrary;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCommonLibrary
{
    public class TcpServer
    {
        public TcpServer(ILogger<TcpServer> logger, BaseConfig baseConfig)
        {
            Logger = logger;
            BaseConfig = baseConfig;
            TcpIOCPServer = new TcpIOCPServer();
        }
        private ILogger<TcpServer> Logger { get; set; }
        private BaseConfig BaseConfig { get; set; }
        private TcpIOCPServer TcpIOCPServer { get; set; }
    }
}
