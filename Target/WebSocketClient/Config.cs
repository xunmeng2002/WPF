using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebSocketClient
{
    public class Config
    {
        public static Config? Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            return JsonSerializer.Deserialize<Config>(fs);
        }
        public string ServerAddress { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
