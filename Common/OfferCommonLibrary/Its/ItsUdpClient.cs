using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OfferCommonLibrary.Its
{
    public class ItsUdpClient
    {
        public void Connect(IPEndPoint ipEndPoint)
        {
            m_UdpClient.Connect(ipEndPoint);
        }
        public bool ZipSend(byte[] data)
        {
            MemoryStream compressed = new MemoryStream();
            ZLibStream zlibStream = new ZLibStream(compressed, CompressionLevel.Fastest);
            zlibStream.Write(data, 0, data.Length);
            zlibStream.Close();
            return Send(compressed.ToArray());
        }
        public bool Send(byte[] data)
        {
            ReadOnlySpan<byte> bytes = new ReadOnlySpan<byte>(data, 0, data.Length);
            while (true)
            {
                int len = m_UdpClient.Send(bytes);
                if (len <= 0)
                {
                    return false;
                }
                if(len == bytes.Length)
                {
                    break;
                }
                bytes = bytes[len..];
            }
            return true;
        }
        private UdpClient m_UdpClient = new UdpClient();
    }
}
