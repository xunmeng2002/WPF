using OfferCommonLibrary;
using System;
using System.IO;
using System.Text.Json;

namespace CmeQuickFixOffer
{
    public class Config : BaseConfig
    {
        public static Config? Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            return JsonSerializer.Deserialize<Config>(fs);
        }
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
