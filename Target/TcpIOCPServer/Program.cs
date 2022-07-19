using System.Net;

namespace TcpIOCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TcpIOCPServer tcpIOCPServer = new TcpIOCPServer(10, 64 * 1024);
            TcpSubscribeImpl tcpSubscribeImpl = new TcpSubscribeImpl(tcpIOCPServer);
            tcpIOCPServer.RegisterSubscribe(tcpSubscribeImpl);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 10000);
            tcpIOCPServer.Init(iPEndPoint);
            tcpIOCPServer.Start();

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}

