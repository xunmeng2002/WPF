using System.Net;
using CommonLibrary;

namespace TcpIOCPServer
{
    class Program
    {
        static void Main(string[] args)
        {

            CommonLibrary.TcpIOCPServer tcpIOCPServer = new CommonLibrary.TcpIOCPServer(10, 64 * 1024);
            TcpSubscribeImpl tcpSubscribeImpl = new TcpSubscribeImpl(tcpIOCPServer);
            tcpIOCPServer.RegisterSubscribe(tcpSubscribeImpl);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 10000);
            tcpIOCPServer.Init();
            tcpIOCPServer.Start(ipEndPoint);

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}

