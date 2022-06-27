using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;

namespace WebSocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Communicate();

            Console.Read();
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
        static async void Communicate()
        {
            ClientWebSocket clientWebSocket = new ClientWebSocket();
            //Uri uri = new Uri("ws://192.168.137.129:9000");
            Uri uri = new Uri("ws://127.0.0.1:10000");
            CancellationToken token = new CancellationToken();
            await clientWebSocket.ConnectAsync(uri, token);

            Console.WriteLine("WebSocketState: {0}", clientWebSocket.State);

            int index = 0;
            while (clientWebSocket.State == WebSocketState.Open && index++ < 5)
            {
                byte[] sendArray = Encoding.UTF8.GetBytes("HelloWorld!");
                PrintByteArray(sendArray, sendArray.Length, "sendArray");

                await clientWebSocket.SendAsync(new ArraySegment<byte>(sendArray), WebSocketMessageType.Binary, true, token);

                byte[] recvArray = new byte[4096];
                WebSocketReceiveResult result = await clientWebSocket.ReceiveAsync(recvArray, token);
                var recvMsg = Encoding.UTF8.GetString(recvArray);

                PrintByteArray(recvArray, result.Count, "recvArray");
                Console.WriteLine("recvMsg: {0}, Len:{1}", recvMsg, recvMsg.Length);
            }
            await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, token);
        }
    }
}
