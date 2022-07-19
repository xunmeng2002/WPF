using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpIOCPServer
{
    public interface TcpSubscribe
    {
        void OnConnected(int sessionID);
        void OnDisconnected(int sessionID);
        void OnRecv(int sessionID, byte[] msg, int offset, int len);
    }
    public class TcpIOCPServer
    {
        int m_MaxSessionID;
        int m_numConnections;
        int m_numConnectedSockets;
        BufferPool m_bufferPool;
        Socket? listenSocket;
        IPEndPoint? m_IPEndPoint;
        TcpSubscribe? m_TcpSubscribe;
        int m_receiveBufferSize;
        SocketAsyncEventArgsPool m_sendPool;
        SocketAsyncEventArgsPool m_recvPool;
        Dictionary<int, Socket> m_Connects = new Dictionary<int, Socket>();

        public TcpIOCPServer(int numConnections, int receiveBufferSize)
        {
            m_MaxSessionID = 0;
            m_numConnectedSockets = 0;
            m_numConnections = numConnections;
            m_receiveBufferSize = receiveBufferSize;

            m_bufferPool = new BufferPool(numConnections, receiveBufferSize);
            m_sendPool = new SocketAsyncEventArgsPool(numConnections);
            m_recvPool = new SocketAsyncEventArgsPool(numConnections);
        }
        public void RegisterSubscribe(TcpSubscribe tcpSubscribe)
        {
            m_TcpSubscribe = tcpSubscribe;
        }
        public void Init(IPEndPoint ipEndPoint)
        {
            m_IPEndPoint = ipEndPoint;
            listenSocket = new Socket(m_IPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(m_IPEndPoint);
            listenSocket.Listen(m_numConnections);

            SocketAsyncEventArgs sendEventArg;
            SocketAsyncEventArgs recvEventArg;
            for (int i = 0; i < m_numConnections; i++)
            {
                sendEventArg = GetSendEventArgs();
                m_sendPool.Push(sendEventArg);
                recvEventArg = GetRecvEventArgs();
                m_recvPool.Push(recvEventArg);
            }
        }
        public void Start()
        {
            for (int i = 0; i < m_numConnections; i++)
            {
                PostAccept(null);
            }
        }
        public void Send(int sessionID, byte[] msg, int offset, int len)
        {
            Socket? socket = GetConnect(sessionID);
            if (socket == null)
            {
                Console.WriteLine($"GetConnect Failed For SessionID:{sessionID}");
                return;
            }

            SocketAsyncEventArgs sendEventArgs = GetSendEventArgs();
            sendEventArgs.UserToken = new AsyncUserToken(sessionID, socket);
            sendEventArgs.SetBuffer(msg, offset, len);
            PostSend(sendEventArgs);
        }
        public void Send(int sessionID, string msg)
        {
            Socket? socket = GetConnect(sessionID);
            if (socket == null)
            {
                Console.WriteLine($"GetConnect Failed For SessionID:{sessionID}");
                return;
            }

            SocketAsyncEventArgs sendEventArgs = GetSendEventArgs();
            sendEventArgs.UserToken = new AsyncUserToken(sessionID, socket);
            byte[] sendData = Encoding.UTF8.GetBytes(msg);
            sendEventArgs.SetBuffer(sendData);
            PostSend(sendEventArgs);
        }
        private Socket? GetConnect(int sessionID)
        {
            Socket? socket;
            lock (m_Connects)
            {
                m_Connects.TryGetValue(sessionID, out socket);
            }
            return socket;
        }
        private void AddConnect(int sessionID, Socket socket)
        {
            lock (m_Connects)
            {
                m_Connects.Add(sessionID, socket);
            }
        }
        private void RemoveConnect(int sessionID)
        {
            lock (m_Connects)
            {
                m_Connects.Remove(sessionID);
            }
        }
        private SocketAsyncEventArgs GetSendEventArgs()
        {
            SocketAsyncEventArgs? sendEventArgs = m_sendPool.Pop();
            if (sendEventArgs == null)
            {
                sendEventArgs = CreateEventArgs();
            }
            return sendEventArgs;
        }
        private SocketAsyncEventArgs GetRecvEventArgs()
        {
            SocketAsyncEventArgs? recvEventArgs = m_recvPool.Pop();
            if (recvEventArgs == null)
            {
                recvEventArgs = CreateEventArgs();
                recvEventArgs.SetBuffer(m_bufferPool.Pop(), 0, m_receiveBufferSize);
            }
            return recvEventArgs;
        }
        private SocketAsyncEventArgs CreateEventArgs()
        {
            SocketAsyncEventArgs eventArgs = new SocketAsyncEventArgs();
            eventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);
            return eventArgs;
        }
        private void PostAccept(SocketAsyncEventArgs? acceptEventArg)
        {
            if (acceptEventArg == null)
            {
                acceptEventArg = new SocketAsyncEventArgs();
                acceptEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);
            }
            else
            {
                acceptEventArg.AcceptSocket = null;
            }
            bool willRaiseEvent = listenSocket.AcceptAsync(acceptEventArg);
            if (!willRaiseEvent)
            {
                AcceptCompleted(acceptEventArg);
            }
        }
        private void PostSend(SocketAsyncEventArgs sendEventArg)
        {
            if (sendEventArg.UserToken == null)
            {
                Console.WriteLine("PostSend Error. UserToken is null");
                return;
            }
            AsyncUserToken token = (AsyncUserToken)sendEventArg.UserToken;
            bool willRaiseEvent = token.Socket.SendAsync(sendEventArg);
            if (!willRaiseEvent)
            {
                SendCompleted(sendEventArg);
            }
        }
        private void PostRecv(SocketAsyncEventArgs recvEventArg)
        {
            AsyncUserToken? token = recvEventArg.UserToken as AsyncUserToken;
            bool willRaiseEvent = token.Socket.ReceiveAsync(recvEventArg);
            if (!willRaiseEvent)
            {
                RecvCompleted(recvEventArg);
            }
        }
        private void IO_Completed(object? sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Accept:
                    AcceptCompleted(e);
                    break;
                case SocketAsyncOperation.Send:
                    SendCompleted(e);
                    break;
                case SocketAsyncOperation.Receive:
                    RecvCompleted(e);
                    break;
                default:
                    throw new ArgumentException("The last operation completed on the socket was not a receive or send");
            }
        }
        private void AcceptCompleted(SocketAsyncEventArgs acceptEventArg)
        {
            Interlocked.Increment(ref m_numConnectedSockets);
            Console.WriteLine("Client connection accepted. There are {0} clients connected to the server", m_numConnectedSockets);
            Console.WriteLine($"AcceptCompleted RemoteEndPoint:{acceptEventArg.AcceptSocket?.RemoteEndPoint?.ToString()}");

            if (acceptEventArg.SocketError == SocketError.Success && acceptEventArg.AcceptSocket != null)
            {
                SocketAsyncEventArgs? recvEventArgs = GetRecvEventArgs();
                int sessionID = ++m_MaxSessionID;
                recvEventArgs.UserToken = new AsyncUserToken(sessionID, acceptEventArg.AcceptSocket);

                AddConnect(sessionID, acceptEventArg.AcceptSocket);

                PostRecv(recvEventArgs);
                m_TcpSubscribe?.OnConnected(sessionID);
            }
            else
            {
                Console.WriteLine("AcceptCompleted Failed. SocketError:{0}, AcceptSocket:{1}", acceptEventArg.SocketError, acceptEventArg.AcceptSocket);
            }
            PostAccept(acceptEventArg);
        }
        private void SendCompleted(SocketAsyncEventArgs sendEventArg)
        {
            Console.WriteLine($"SendCompleted, BytesTransferred: {sendEventArg.BytesTransferred}");
            if (sendEventArg.SocketError != SocketError.Success)
            {
                Console.WriteLine($"Send Failed! SocketError:{sendEventArg.SocketError}");
                CloseClientSocket(sendEventArg);
            }
            else
            {
                m_sendPool.Push(sendEventArg);
            }
        }
        private void RecvCompleted(SocketAsyncEventArgs recvEventArg)
        {
            Console.WriteLine($"RecvCompleted, BytesTransferred: {recvEventArg.BytesTransferred}");
            if (recvEventArg.SocketError != SocketError.Success)
            {
                Console.WriteLine($"Recv Failed! SocketError:{recvEventArg.SocketError}");
                CloseClientSocket(recvEventArg);
            }
            else if (recvEventArg.BytesTransferred == 0)
            {
                Console.WriteLine($"Recv 0 byte. Do DisConnect.");
                CloseClientSocket(recvEventArg);
            }
            else
            {
                if (recvEventArg.UserToken == null)
                {
                    Console.WriteLine("Recv Error, UserToken is null");
                }
                else if (recvEventArg.Buffer == null)
                {
                    Console.WriteLine("Recv Error, Buffer is null");
                }
                else
                {
                    AsyncUserToken token = (AsyncUserToken)recvEventArg.UserToken;
                    m_TcpSubscribe?.OnRecv(token.SessionID, recvEventArg.Buffer, recvEventArg.Offset, recvEventArg.BytesTransferred);
                }
                PostRecv(recvEventArg);
            }
        }
        private void CloseClientSocket(SocketAsyncEventArgs e)
        {
            if (e.UserToken == null)
            {
                Console.WriteLine($"CloseClientSocket Error For UserToken is null.");
                return;
            }
            AsyncUserToken token = (AsyncUserToken)e.UserToken;
            Console.WriteLine($"CloseClientSocket SessionID:{token.SessionID}, Socket:{token.Socket.Handle.ToInt64()}");
            token.Socket.Shutdown(SocketShutdown.Send);
            token.Socket.Close();
            RemoveConnect(token.SessionID);

            Interlocked.Decrement(ref m_numConnectedSockets);
            if (e.LastOperation == SocketAsyncOperation.Receive)
            {
                m_recvPool.Push(e);
            }
            else if (e.LastOperation == SocketAsyncOperation.Send)
            {
                m_sendPool.Push(e);
            }
            else
            {
                Console.WriteLine($"Unexpected Operation while Close Client Socket. LastOperation:{e.LastOperation}");
            }
        }
    }
}
