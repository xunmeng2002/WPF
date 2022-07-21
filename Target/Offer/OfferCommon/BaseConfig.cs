using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCommon
{
    public class BaseConfig
    {
        public int ChannelID { get; set; }
        public string ListenIP { get; set; } = string.Empty;
        public int ListenPort { get; set; }
        public string UdpIP { get; set; } = string.Empty;
        public int UdpPort { get; set; }
    }
}
