﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class TcpIOCP : ITcp
    {
        protected ILogger Logger;
        protected long m_MaxSessionID;
        protected int m_NumConnections;
        protected BufferPool m_BufferPool;
        protected IPEndPoint? m_IPEndPoint;
        protected Socket? m_ListenSocket;

        protected ITcpSubscribe? m_TcpSubscribe;
        protected int m_ReceiveBufferSize;
        protected SocketAsyncEventArgsPool m_ConnectPool;
        protected SocketAsyncEventArgsPool m_SendPool;
        protected SocketAsyncEventArgsPool m_RecvPool;
        protected List<UserToken> m_Connects = new List<UserToken>();

        public TcpIOCP(ILogger logger, int numConnections, int receiveBufferSize)
        {
            Logger = logger;
            m_MaxSessionID = 0;
            m_NumConnections = numConnections;
            m_ReceiveBufferSize = receiveBufferSize;

            m_BufferPool = new BufferPool(numConnections, receiveBufferSize);
            m_ConnectPool = new SocketAsyncEventArgsPool(numConnections);
            m_SendPool = new SocketAsyncEventArgsPool(numConnections);
            m_RecvPool = new SocketAsyncEventArgsPool(numConnections);
        }
        public void Init()
        {
            SocketAsyncEventArgs sendEventArg;
            SocketAsyncEventArgs recvEventArg;
            for (int i = 0; i < m_NumConnections; i++)
            {
                sendEventArg = GetSendEventArgs();
                m_SendPool.Push(sendEventArg);
                recvEventArg = GetRecvEventArgs();
                m_RecvPool.Push(recvEventArg);
            }
        }
        public void RegisterSubscribe(ITcpSubscribe tcpSubscribe)
        {
            m_TcpSubscribe = tcpSubscribe;
        }
        public bool Send(UserToken userToken, byte[] msg, int offset, int len)
        {
            SocketAsyncEventArgs sendEventArgs = GetSendEventArgs();
            sendEventArgs.UserToken = userToken;
            sendEventArgs.SetBuffer(msg, offset, len);
            PostSend(sendEventArgs);
            return true;
        }

        public bool Send(UserToken userToken, string msg)
        {
            SocketAsyncEventArgs sendEventArgs = GetSendEventArgs();
            sendEventArgs.UserToken = userToken;
            byte[] sendData = Encoding.UTF8.GetBytes(msg);
            sendEventArgs.SetBuffer(sendData);
            PostSend(sendEventArgs);
            return true;
        }

        protected SocketAsyncEventArgs GetConnectEventArgs()
        {
            SocketAsyncEventArgs? connectEventArgs = m_ConnectPool.Pop();
            if (connectEventArgs == null)
            {
                connectEventArgs = CreateEventArgs();
            }
            return connectEventArgs;
        }
        protected SocketAsyncEventArgs GetSendEventArgs()
        {
            SocketAsyncEventArgs? sendEventArgs = m_SendPool.Pop();
            if (sendEventArgs == null)
            {
                sendEventArgs = CreateEventArgs();
            }
            return sendEventArgs;
        }
        protected SocketAsyncEventArgs GetRecvEventArgs()
        {
            SocketAsyncEventArgs? recvEventArgs = m_RecvPool.Pop();
            if (recvEventArgs == null)
            {
                recvEventArgs = CreateEventArgs();
                recvEventArgs.SetBuffer(m_BufferPool.Pop(), 0, m_ReceiveBufferSize);
            }
            return recvEventArgs;
        }
        protected SocketAsyncEventArgs CreateEventArgs()
        {
            SocketAsyncEventArgs eventArgs = new SocketAsyncEventArgs();
            eventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);
            return eventArgs;
        }
        protected void AddConnect(UserToken userToken)
        {
            lock (m_Connects)
            {
                m_Connects.Add(userToken);
            }
            m_TcpSubscribe?.OnConnected(userToken);
        }
        protected void RemoveConnect(UserToken userToken)
        {
            lock (m_Connects)
            {
                m_Connects.Remove(userToken);
            }
            m_TcpSubscribe?.OnDisconnected(userToken);
        }


        protected void PostConnect(IPEndPoint ipEndPoint)
        {
            Socket socket = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            UserToken token = new UserToken(++m_MaxSessionID, socket, ipEndPoint);
            SocketAsyncEventArgs connectEventArg = GetConnectEventArgs();
            connectEventArg.RemoteEndPoint = ipEndPoint;
            connectEventArg.UserToken = token;

            bool willRaiseEvent = socket.ConnectAsync(connectEventArg);
            if (!willRaiseEvent)
            {
                ConnectCompleted(connectEventArg);
            }
        }
        protected void PostDisconnect(UserToken userToken)
        {
            SocketAsyncEventArgs disconnectEventArg = GetConnectEventArgs();
            disconnectEventArg.UserToken = userToken;

            bool willRaiseEvent = userToken.Socket.DisconnectAsync(disconnectEventArg);
            if (!willRaiseEvent)
            {
                DisconnectCompleted(disconnectEventArg);
            }
        }
        protected void PostAccept(SocketAsyncEventArgs? acceptEventArg)
        {
            if (m_ListenSocket == null)
            {
                throw new ArgumentException("PostAccept Failed for ListenSocket is null");
            }
            if (acceptEventArg == null)
            {
                acceptEventArg = CreateEventArgs();
            }
            else
            {
                acceptEventArg.AcceptSocket = null;
            }
            bool willRaiseEvent = m_ListenSocket.AcceptAsync(acceptEventArg);
            if (!willRaiseEvent)
            {
                AcceptCompleted(acceptEventArg);
            }
        }
        protected void PostSend(SocketAsyncEventArgs sendEventArg)
        {
            if (sendEventArg.UserToken == null)
            {
                throw new ArgumentException("PostSend Failed for UserToken is null");
            }
            UserToken token = (UserToken)sendEventArg.UserToken;
            bool willRaiseEvent = token.Socket.SendAsync(sendEventArg);
            if (!willRaiseEvent)
            {
                SendCompleted(sendEventArg);
            }
        }
        protected void PostRecv(SocketAsyncEventArgs recvEventArg)
        {
            if (recvEventArg.UserToken == null)
            {
                throw new ArgumentException("PostRecv Failed for UserToken is null");
            }
            UserToken token = (UserToken)recvEventArg.UserToken;
            bool willRaiseEvent = token.Socket.ReceiveAsync(recvEventArg);
            if (!willRaiseEvent)
            {
                RecvCompleted(recvEventArg);
            }
        }
        protected void IO_Completed(object? sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Connect:
                    ConnectCompleted(e);
                    break;
                case SocketAsyncOperation.Disconnect:
                    DisconnectCompleted(e);
                    break;
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
        protected void ConnectCompleted(SocketAsyncEventArgs connectEventArgs)
        {
            Logger.LogInformation($"ConnectCompleted RemoteEndPoint:{connectEventArgs.RemoteEndPoint?.ToString()}");
            if (connectEventArgs.SocketError != SocketError.Success)
            {
                Logger.LogInformation($"Connect Failed! SocketError:{connectEventArgs.SocketError}");
                CloseClientSocket(connectEventArgs);
            }
            else 
            {
                if (connectEventArgs.UserToken == null)
                {
                    throw new ArgumentException("Connect Error, UserToken is null");
                }
                else
                {
                    UserToken token = (UserToken)connectEventArgs.UserToken;
                    if(token.Socket != connectEventArgs.ConnectSocket)
                    {
                        throw new ArgumentException("Recv Error, Buffer is null");
                    }
                    AddConnect(token);
                    connectEventArgs.SetBuffer(m_BufferPool.Pop(), 0, m_ReceiveBufferSize);
                    PostRecv(connectEventArgs);
                }
            }
        }
        protected void DisconnectCompleted(SocketAsyncEventArgs disconnectEventArgs)
        {
            Logger.LogInformation($"DisconnectCompleted SocketError:{disconnectEventArgs.SocketError}");
            CloseClientSocket(disconnectEventArgs);
        }
        protected void AcceptCompleted(SocketAsyncEventArgs acceptEventArg)
        {
            Logger.LogInformation($"AcceptCompleted RemoteEndPoint:{acceptEventArg.AcceptSocket?.RemoteEndPoint?.ToString()}");
            if (acceptEventArg.SocketError != SocketError.Success)
            {
                Logger.LogInformation($"AcceptCompleted Failed. SocketError:{acceptEventArg.SocketError}, AcceptSocket:{acceptEventArg.AcceptSocket}");
                return;
            }
            else if(acceptEventArg.AcceptSocket == null)
            {
                throw new ArgumentException("AcceptSocket is null");
            }
            else
            {
                SocketAsyncEventArgs recvEventArgs = GetRecvEventArgs();
                long sessionID = ++m_MaxSessionID;
                UserToken userToken = new UserToken(sessionID, acceptEventArg.AcceptSocket, (IPEndPoint?)acceptEventArg.AcceptSocket.RemoteEndPoint);
                recvEventArgs.UserToken = userToken;
                AddConnect(userToken);
                PostRecv(recvEventArgs);
                PostAccept(acceptEventArg);
            }
        }
        protected void SendCompleted(SocketAsyncEventArgs sendEventArg)
        {
            Logger.LogInformation($"SendCompleted, BytesTransferred: {sendEventArg.BytesTransferred}");
            if (sendEventArg.SocketError != SocketError.Success)
            {
                Logger.LogInformation($"Send Failed! SocketError:{sendEventArg.SocketError}");
                CloseClientSocket(sendEventArg);
            }
            else
            {
                m_SendPool.Push(sendEventArg);
            }
        }
        protected void RecvCompleted(SocketAsyncEventArgs recvEventArg)
        {
            Logger.LogInformation($"RecvCompleted, BytesTransferred: {recvEventArg.BytesTransferred}");
            if (recvEventArg.SocketError != SocketError.Success)
            {
                Logger.LogInformation($"Recv Failed! SocketError:{recvEventArg.SocketError}");
                CloseClientSocket(recvEventArg);
            }
            else if (recvEventArg.BytesTransferred == 0)
            {
                Logger.LogInformation($"Recv 0 byte. Do DisConnect.");
                CloseClientSocket(recvEventArg);
            }
            else
            {
                if (recvEventArg.UserToken == null)
                {
                    throw new ArgumentException("Recv Error, UserToken is null");
                }
                else if (recvEventArg.Buffer == null)
                {
                    throw new ArgumentException("Recv Error, Buffer is null");
                }
                else
                {
                    UserToken userToken = (UserToken)recvEventArg.UserToken;
                    m_TcpSubscribe?.OnRecv(userToken, recvEventArg.Buffer, recvEventArg.Offset, recvEventArg.BytesTransferred);
                }
                PostRecv(recvEventArg);
            }
        }

        protected void CloseClientSocket(SocketAsyncEventArgs e)
        {
            if (e.UserToken == null)
            {
                throw new ArgumentException($"CloseClientSocket Error For UserToken is null.");
            }
            UserToken userToken = (UserToken)e.UserToken;
            Logger.LogInformation($"CloseClientSocket SessionID:{userToken.SessionID}, Socket:{userToken.Socket.Handle.ToInt64()}");
            userToken.Socket.Close();
            RemoveConnect(userToken);

            if (e.LastOperation == SocketAsyncOperation.Connect || e.LastOperation == SocketAsyncOperation.Disconnect)
            {
                m_ConnectPool.Push(e);
            }
            else if (e.LastOperation == SocketAsyncOperation.Receive)
            {
                m_RecvPool.Push(e);
            }
            else if (e.LastOperation == SocketAsyncOperation.Send)
            {
                m_SendPool.Push(e);
            }
            else
            {
                Logger.LogInformation($"Unexpected Operation while Close Client Socket. LastOperation:{e.LastOperation}");
            }
        }
    }
}

