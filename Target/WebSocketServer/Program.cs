using System;
using System.Net.WebSockets;

namespace WebSocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            WebSocketServer webSocketServer = new WebSocketServer();
            webSocketServer.Start(10000);
        }
    }
}
