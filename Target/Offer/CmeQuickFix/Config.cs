using System;

namespace CmeQuickFix
{
    public class Config
    {
        public int ChannelID { get; set; }
        public string ListenIP { get; set; } = string.Empty;
        public int ListenPort { get; set; }
        public string UdpIP { get; set; } = string.Empty;
        public int UdpPort { get; set; }
        public string CommodityFile { get; set; } = string.Empty;
        public string LoginSenderCompID { get; set; } = string.Empty;
        public string ApplicationSystemName { get; set; } = string.Empty;
        public string ApplicationSystemVersion { get; set; } = string.Empty;
        public string ApplicationSystemVendor { get; set; } = string.Empty;
        public string AccessID { get; set; } = string.Empty;
        public string EncryptedPasswordMethod { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
        public string Account { get; set; } = string.Empty;
    }
}
