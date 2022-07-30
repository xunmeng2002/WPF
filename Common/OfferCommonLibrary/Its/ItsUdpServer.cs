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
    public class ItsUdpServer
    {
        public ItsUdpServer(IPEndPoint ipEndPoint)
        {
            m_UdpServer = new UdpClient(ipEndPoint);
        }
        public byte[] ZipSend(ref IPEndPoint? remoteAddress)
        {
            byte[] data = Recv(ref remoteAddress);

            MemoryStream compressed = new MemoryStream(data);
            ZLibStream zlibStream = new ZLibStream(compressed, CompressionMode.Decompress);
            MemoryStream decompressed = new MemoryStream();
            zlibStream.CopyTo(decompressed);
            return decompressed.ToArray();
        }
        public byte[] Recv(ref IPEndPoint? remoteAddress)
        {
            return m_UdpServer.Receive(ref remoteAddress);
        }
        private UdpClient m_UdpServer;
    }
}
