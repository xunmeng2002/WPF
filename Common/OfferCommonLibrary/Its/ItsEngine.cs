﻿using CommonLibrary;
using Microsoft.Extensions.Logging;
using OfferCommonLibrary.Mdb;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace OfferCommonLibrary.Its
{
    public class ItsEngine : PropertyChangedNotify, ITcpSubscribe
    {
        public ItsEngine(ILogger<ItsEngine> logger, BaseConfig baseConfig)
        {
            m_Logger = logger;
            m_BaseConfig = baseConfig;
            m_ChannelID = baseConfig.ChannelID;


            m_TcpIOCPServer = new TcpIOCPServer(m_Logger);
            m_ItsUdpClient.Connect(new IPEndPoint(IPAddress.Parse(baseConfig.UdpIP), baseConfig.UdpPort));
        }
        private ILogger<ItsEngine> m_Logger { get; set; }
        private BaseConfig m_BaseConfig { get; set; }
        private MdbEngine? m_MdbEngine { get; set; }
        private TcpIOCPServer m_TcpIOCPServer { get; set; }
        public ItsUdpClient m_ItsUdpClient { get; set; } = new ItsUdpClient();
        public ObservableCollection<UserToken> m_Connects { get; set; } = new ObservableCollection<UserToken>();
        public int m_ChannelID { get; set; }

        public void Init(MdbEngine mdbEngine)
        {
            m_MdbEngine = mdbEngine;
            m_TcpIOCPServer.RegisterSubscribe(this);
            m_TcpIOCPServer.Init();
        }
        public void Start()
        {
            m_TcpIOCPServer.Start(new IPEndPoint(IPAddress.Any, m_BaseConfig.ListenPort));
        }
        public bool Send(UserToken userToken, byte[] msg, int offset, int len)
        {
            return m_TcpIOCPServer.Send(userToken, msg, offset, len);
        }
        public bool Send(UserToken userToken, string msg)
        {
            return m_TcpIOCPServer.Send(userToken, msg);
        }


        public void OnConnected(UserToken userToken)
        {
            m_Logger.LogInformation($"ItsEngine OnConnected UserToken:{userToken.ToString()}");
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() => m_Connects.Add(userToken)));
        }
        public void OnDisconnected(UserToken userToken)
        {
            m_Logger.LogInformation($"ItsEngine OnDisconnected UserToken:{userToken.ToString()}");
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() => m_Connects.Remove(userToken)));
        }
        public void OnRecv(UserToken userToken, byte[] msg, int offset, int len)
        {
            short msgLen = (short)(msg[0] | (msg[1] << 8));
            m_Logger.LogInformation($"ItsEngine OnRecv UserToken:{userToken.ToString()} Len:{len} msgLen:{msgLen}");
            offset += 2;
            string msgStr = Encoding.UTF8.GetString(msg, offset, msgLen);
            m_Logger.LogInformation($"OnRecv msgStr:{msgStr}");
            string[] items = msgStr.Split('|');
            if (!CheckItsMessage(items))
            {
                m_Logger.LogWarning($"Invalid Message for mesStr:[{msgStr}]");
                return;
            }
            int cmd = int.Parse(items[1]);
            switch(cmd)
            {
                case 216:
                    HandleItsInsertOrder(userToken, new ItsInsertOrder(items));
                    break;
                case 217:
                    HandleItsInsertOrderCancel(userToken, new ItsInsertOrderCancel(items));
                    break;
                default:
                    break;
            }
        }
        bool CheckItsMessage(string[] items)
        {
            if (items.Length < 2 || items[0] != "R")
            {
                return false;
            }
            
            int cmd = int.Parse(items[1]);
            switch (cmd)
            {
                case 216:
                    if (items.Length < 27)
                    {
                        return false;
                    }
                    break;
                case 217:
                    if (items.Length < 18)
                    {
                        return false;
                    }
                    break;
                default:
                    return false;
            }
            return true;
        }
        void HandleItsInsertOrder(UserToken userToken, ItsInsertOrder itsInsertOrder)
        {
            m_MdbEngine?.InsertOrder(userToken, itsInsertOrder);
        }
        void HandleItsInsertOrderCancel(UserToken userToken, ItsInsertOrderCancel itsInsertOrderCancel)
        {
            m_MdbEngine?.InsertOrderCancel(userToken, itsInsertOrderCancel);
        }

        public void OnRtnOrder(ItsOrder field) { }
        public void OnRtnTrade(ItsTrade field) { }
        public void OnRtnOrderCancel(ItsRtnOrderCancel field) { }
        public void OnRspOrder(UserToken userToken, ItsRspOrder field) { }
    }
}
