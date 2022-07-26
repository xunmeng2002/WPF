using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCommonLibrary
{
    public class BaseConfig
    {
        public BaseConfig()
        {

        }
        public BaseConfig(BaseConfig other)
        {
            ChannelID = other.ChannelID;
            ListenIP = other.ListenIP;
            ListenPort = other.ListenPort;
            UdpIP = other.UdpIP;
            UdpPort = other.UdpPort;
        }

        public int ChannelID { get; set; }
        public string ListenIP { get; set; } = string.Empty;
        public int ListenPort { get; set; }
        public string UdpIP { get; set; } = string.Empty;
        public int UdpPort { get; set; }
    }
}
