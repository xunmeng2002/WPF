using System.Net;

namespace TcpIOCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CommonLibrary.TcpIOCPClient tcpIOCPClient = new CommonLibrary.TcpIOCPClient(10, 64 * 1024);
            TcpSubscribeImpl tcpSubscribeImpl = new TcpSubscribeImpl(tcpIOCPClient);
            tcpIOCPClient.RegisterSubscribe(tcpSubscribeImpl);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10000);
            tcpIOCPClient.Init();
            for(int i = 0; i < 10; i++)
            {
                tcpIOCPClient.Connect(ipEndPoint);
            }

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}

