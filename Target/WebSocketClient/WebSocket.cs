using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WebSocketClient.Mdb;
using WebSocketClient.Xmans;

namespace WebSocketClient
{
    public class WebSocket : PropertyChangedNotify
    {
        public WebSocket(ILogger<WebSocket> logger)
        {
            Logger = logger;
        }
        public void Init(MainWindow? mainWindow, MdbEngine? mdbEngine)
        {
            MainWindow = mainWindow;
            MdbEngine = mdbEngine;
        }
        private ILogger<WebSocket> Logger { get; set; }
        private MainWindow? MainWindow { get; set; }
        private MdbEngine? MdbEngine { get; set; }
        public ClientWebSocket ClientWebSocket = new ClientWebSocket();
        private CancellationToken Token = new CancellationToken();
        private byte[] RecvBuff = new byte[4096];

        public void UpdateConnectStatus()
        {
            MdbEngine?.UpdateConnectStatus(ClientWebSocket.State);
        }
        public async Task Connect(Uri uri)
        {
            await ClientWebSocket.ConnectAsync(uri, Token);

            UpdateConnectStatus();
            await Recv();
        }
        public async Task Send(string msg)
        {
            byte[] sendArray = Encoding.UTF8.GetBytes(msg);
            await ClientWebSocket.SendAsync(sendArray, WebSocketMessageType.Binary, true, Token);
        }
        private async Task Recv()
        {
            WebSocketReceiveResult webSocketReceiveResult = await ClientWebSocket.ReceiveAsync(RecvBuff, Token);

            string msg = Encoding.UTF8.GetString(RecvBuff, 0, webSocketReceiveResult.Count);
            MainWindow?.OnRecv(msg);
            ParseBuff(msg);
            if (ClientWebSocket.State == WebSocketState.Open)
            {
                await Recv();
            }
        }

        private void ParseBuff(string msg)
        {
            JsonDocument jsonDocument = JsonDocument.Parse(msg);
            string? type = jsonDocument.RootElement.GetProperty("msgtype").GetString();
            switch (type)
            {
                case "ReqLogin":
                    ReqLogin? reqLogin = jsonDocument.Deserialize<ReqLogin>();
                    if (reqLogin == null)
                    {
                        MainWindow?.OnStatusMsg("Failed to Deserialize " + type);
                    }
                    else
                    {
                        MainWindow?.OnStatusMsg("Recv " + type);
                        MdbEngine?.OnLogin();
                    }
                    break;
                case "ReqOrder":
                    ReqOrder? reqOrder = jsonDocument.Deserialize<ReqOrder>();
                    if (reqOrder == null)
                    {
                        MainWindow?.OnStatusMsg("Failed to Deserialize " + type);
                    }
                    else
                    {
                        MainWindow?.OnStatusMsg("Recv " + type);
                        var reqOrderField = reqOrder.data[0];

                        Order order = new Order();
                        order.AccountID = reqOrderField.customerId;
                        order.ExchangeID = reqOrderField.market.ToString();
                        order.InstrumentID = reqOrderField.securityId;
                        order.Direction = (Direction)reqOrderField.bsType;
                        order.OrderPriceType = (OrderPriceType)reqOrderField.ordType;
                        order.Price = ((double)reqOrderField.ordPrice) / 10000;
                        order.Volume = reqOrderField.ordQty;
                        order.VolumeTraded = 0;
                        order.OrderStatus = OrderStatus.Inserted;
                        order.RequestID = reqOrderField.frontId;
                        order.SessionID = MainWindow.SessionID;
                        order.InsertDate = DateTime.Now.ToString("yyyyMMdd");
                        order.InsertTime = DateTime.Now.ToString("HH:mm:ss");
                        order.ErrorID = 0;
                        order.ErrorMsg = "";
                        MdbEngine?.OnRtnOrder(order);
                    }
                    break;
                case "RspOrder":
                    RspOrder? rspOrder = jsonDocument.Deserialize<RspOrder>();
                    if (rspOrder == null)
                    {
                        MainWindow?.OnStatusMsg("Failed to Deserialize Order");
                    }
                    else
                    {
                        MainWindow?.OnStatusMsg("Recv " + type);
                    }
                    break;
            }
        }
    }
}
