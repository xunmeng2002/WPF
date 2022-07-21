using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmeQuickFixOffer
{
    internal class UrlBase64
    {
        public static void PrintHex(byte[] bytes, int len, string name)
        {
            Console.Write("{0}:[", name);
            for (var b = 0; b < len; b++)
            {
                Console.Write("{0:X2}", bytes[b]);
            }
            Console.WriteLine("]");
        }
        public static byte[] DecodeFromUtf8(string utf8)
        {
            string urlSrc = utf8.Replace('-', '+').Replace('_', '/');
            if (urlSrc.Length % 4 != 0)
            {
                int len = 4 - urlSrc.Length % 4;
                string app = new string('=', len);
                urlSrc = urlSrc + app;
            }
            char[] chars = urlSrc.ToCharArray();
            return Convert.FromBase64CharArray(chars, 0, chars.Length);
        }
        public static string EncodeToUtf8(byte[] bytes)
        {
            string base64 = Convert.ToBase64String(bytes);
            return base64.Replace("=", string.Empty).Replace('+', '-').Replace('/', '_');
        }
    }
}
