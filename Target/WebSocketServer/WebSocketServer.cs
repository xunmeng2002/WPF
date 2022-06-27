using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace WebSocketServer
{
    public class WebSocketServer
    {
        private Dictionary<string, Session> SessionPool = new Dictionary<string, Session>();
        private Dictionary<string, string> MsgPool = new Dictionary<string, string>();

        public void Start(int port)
        {
            Socket SockeServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            SockeServer.Bind(new IPEndPoint(IPAddress.Any, port));
            SockeServer.Listen(20);
            SockeServer.BeginAccept(new AsyncCallback(Accept), SockeServer);
            Console.WriteLine("服务已启动");
            Console.WriteLine("按任意键关闭服务");
            Console.ReadLine();
        }
        private void Accept(IAsyncResult socket)
        {
            // 还原传入的原始套接字
            Socket SockeServer = (Socket)socket.AsyncState;
            // 在原始套接字上调用EndAccept方法，返回新的套接字
            Socket SockeClient = SockeServer.EndAccept(socket);
            Console.WriteLine("SocketClient: {0}", SockeClient.Handle);
            byte[] buffer = new byte[4096];
            try
            {
                //接收客户端的数据
                SockeClient.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(Recieve), SockeClient);
                //保存登录的客户端
                Session session = new Session();
                session.SockeClient = SockeClient;
                session.IP = SockeClient.RemoteEndPoint.ToString();
                session.buffer = buffer;
                lock (SessionPool)
                {
                    if (SessionPool.ContainsKey(session.IP))
                    {
                        this.SessionPool.Remove(session.IP);
                    }
                    this.SessionPool.Add(session.IP, session);
                }
                //准备接受下一个客户端
                SockeServer.BeginAccept(new AsyncCallback(Accept), SockeServer);
                Console.WriteLine(string.Format("Client {0} connected", SockeClient.RemoteEndPoint));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }
        private void Recieve(IAsyncResult socket)
        {
            Socket SockeClient = (Socket)socket.AsyncState;
            string IP = SockeClient.RemoteEndPoint.ToString();
            if (SockeClient == null || !SessionPool.ContainsKey(IP))
            {
                return;
            }
            try
            {
                int len = SockeClient.EndReceive(socket);
                byte[] recvBuffer = SessionPool[IP].buffer;
                PrintByteArray(recvBuffer, len, "recvBuffer");
                string recvMsg = Encoding.UTF8.GetString(recvBuffer, 0, len);

                SockeClient.BeginReceive(recvBuffer, 0, recvBuffer.Length, SocketFlags.None, new AsyncCallback(Recieve), SockeClient);
                //  websocket建立连接的时候，除了TCP连接的三次握手，websocket协议中客户端与服务器想建立连接需要一次额外的握手动作
                if (recvMsg.Contains("Sec-WebSocket-Key"))
                {
                    Console.WriteLine("recvMsg: {0}, Len: {1}", recvMsg, recvMsg.Length);
                    SockeClient.Send(PackageHandShakeData(recvBuffer, len));
                    SessionPool[IP].isWeb = true;
                    return;
                }
                if (SessionPool[IP].isWeb)
                {
                    recvMsg = AnalyzeClientData(recvBuffer, len);
                }
                Console.WriteLine("AnalyzeClientData MSG: {0}, Len: {1}", recvMsg, recvMsg.Length);
                byte[] sendBuffer = PackageServerData(recvMsg);
                PrintByteArray(sendBuffer, sendBuffer.Length, "sendBuffer");
                foreach (Session se in SessionPool.Values)
                {
                    se.SockeClient.Send(sendBuffer, sendBuffer.Length, SocketFlags.None);
                }
            }
            catch
            {
                SockeClient.Disconnect(true);
                Console.WriteLine("客户端 {0} 断开连接", IP);
                SessionPool.Remove(IP);
            }
        }

        static void PrintByteArray(byte[] array, int len, string name)
        {
            Console.Write("Len:{0} {1}:[", len, name);
            for (int i = 0; i < len; i++)
            {
                Console.Write("{0:X2}", array[i]);
            }
            Console.WriteLine("]");
        }
        private byte[] PackageHandShakeData(byte[] handShakeBytes, int length)
        {
            string handShakeText = Encoding.UTF8.GetString(handShakeBytes, 0, length);
            string key = string.Empty;
            Regex reg = new Regex(@"Sec\-WebSocket\-Key:(.*?)\r\n");
            Match m = reg.Match(handShakeText);
            if (m.Value != "")
            {
                key = Regex.Replace(m.Value, @"Sec\-WebSocket\-Key:(.*?)\r\n", "$1").Trim();
            }
            byte[] secKeyBytes = SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes(key + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"));
            string secKey = Convert.ToBase64String(secKeyBytes);
            var responseBuilder = new StringBuilder();
            responseBuilder.Append("HTTP/1.1 101 Switching Protocols" + "\r\n");
            responseBuilder.Append("Upgrade: websocket" + "\r\n");
            responseBuilder.Append("Connection: Upgrade" + "\r\n");
            responseBuilder.Append("Sec-WebSocket-Accept: " + secKey + "\r\n\r\n");
            return Encoding.UTF8.GetBytes(responseBuilder.ToString());
        }
        private byte[] PackageServerData(string msg)
        {
            byte[] content = null;
            byte[] temp = Encoding.UTF8.GetBytes(msg);
            if (temp.Length < 126)
            {
                content = new byte[temp.Length + 2];
                content[0] = 0x81;
                content[1] = (byte)temp.Length;
                Buffer.BlockCopy(temp, 0, content, 2, temp.Length);
            }
            else if (temp.Length < 0xFFFF)
            {
                content = new byte[temp.Length + 4];
                content[0] = 0x81;
                content[1] = 126;
                content[2] = (byte)(temp.Length & 0xFF);
                content[3] = (byte)(temp.Length >> 8 & 0xFF);
                Buffer.BlockCopy(temp, 0, content, 4, temp.Length);
            }
            return content;
        }
        private string AnalyzeClientData(byte[] recBytes, int length)
        {
            int start = 0;
            // 如果有数据则至少包括3位
            if (length < 2)
                return "";
            // 判断是否为结束针
            bool IsEof = (recBytes[start] >> 7) > 0;
            // 暂不处理超过一帧的数据
            if (!IsEof)
                return "";
            start++;
            // 是否包含掩码
            bool hasMask = (recBytes[start] >> 7) > 0;
            // 不包含掩码的暂不处理
            if (!hasMask)
                return "";
            // 获取数据长度
            UInt64 mPackageLength = (UInt64)recBytes[start] & 0x7F;
            start++;
            // 存储4位掩码值
            byte[] Masking_key = new byte[4];
            // 存储数据
            byte[] mDataPackage;
            if (mPackageLength == 126)
            {
                // 等于126 随后的两个字节16位表示数据长度
                mPackageLength = (UInt64)(recBytes[start] << 8 | recBytes[start + 1]);
                start += 2;
            }
            if (mPackageLength == 127)
            {
                // 等于127 随后的八个字节64位表示数据长度
                mPackageLength = (UInt64)(recBytes[start] << (8 * 7) | recBytes[start] << (8 * 6) | recBytes[start] << (8 * 5) | recBytes[start] << (8 * 4) | recBytes[start] << (8 * 3) | recBytes[start] << (8 * 2) | recBytes[start] << 8 | recBytes[start + 1]);
                start += 8;
            }
            mDataPackage = new byte[mPackageLength];
            for (UInt64 i = 0; i < mPackageLength; i++)
            {
                mDataPackage[i] = recBytes[i + (UInt64)start + 4];
            }
            Buffer.BlockCopy(recBytes, start, Masking_key, 0, 4);
            for (UInt64 i = 0; i < mPackageLength; i++)
            {
                mDataPackage[i] = (byte)(mDataPackage[i] ^ Masking_key[i % 4]);
            }
            return Encoding.UTF8.GetString(mDataPackage);
        }
    }
}
