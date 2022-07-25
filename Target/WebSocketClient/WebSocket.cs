using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketClient
{
    public class WebSocket : PropertyChangedNotify
    {
        public WebSocket(MainWindow window)
        {
            m_MainWindow = window;
        }
        private MainWindow m_MainWindow;
        public ClientWebSocket clientWebSocket = new ClientWebSocket();
        private CancellationToken token = new CancellationToken();
        private byte[] recvBuff = new byte[4096];
        private string connectStatus = "None";
        public string ConnectStatus
        {
            get => connectStatus;
            set
            {
                if (connectStatus == value)
                    return;
                connectStatus = value;
                OnPropertyChanged();
            }
        }

        public void UpdateConnectStatus()
        {
            ConnectStatus = clientWebSocket.State.ToString();
        }
        public async Task Connect(Uri uri)
        {
            ConnectStatus = "Connecting";
            await clientWebSocket.ConnectAsync(uri, token);
            ConnectStatus = clientWebSocket.State.ToString();
            await Recv();
        }
        public async Task Send(string msg)
        {
            ConnectStatus = clientWebSocket.State.ToString();
            byte[] sendArray = Encoding.UTF8.GetBytes(msg);
            await clientWebSocket.SendAsync(sendArray, WebSocketMessageType.Binary, true, token);
        }
        private async Task Recv()
        {
            ConnectStatus = clientWebSocket.State.ToString();
            WebSocketReceiveResult webSocketReceiveResult = await clientWebSocket.ReceiveAsync(recvBuff, token);

            string msg = Encoding.UTF8.GetString(recvBuff, 0, webSocketReceiveResult.Count);
            m_MainWindow.OnRecv(msg);
            ParseBuff(msg);
            if (clientWebSocket.State == WebSocketState.Open)
            {
                await Recv();
            }
        }

        private void ParseBuff(string msg)
        {
            JsonDocument jsonDocument = JsonDocument.Parse(msg);
            string? type = jsonDocument.RootElement.GetProperty("type").GetString();
            switch (type)
            {
                case "reqorder":
                    ReqOrder? reqOrder = jsonDocument.Deserialize<ReqOrder>();
                    if (reqOrder == null)
                    {
                        m_MainWindow.OnStatusMsg("Failed to Deserialize " + type);
                    }
                    else
                    {
                        m_MainWindow.OnStatusMsg("Recv " + type);
                        m_MainWindow.AddOrderFromReqOrder(reqOrder);
                    }
                    return;
                case "order":
                    Order? order = jsonDocument.Deserialize<Order>();
                    if (order == null)
                    {
                        m_MainWindow.OnStatusMsg("Failed to Deserialize Order");
                    }
                    else
                    {
                        m_MainWindow.OnStatusMsg("Recv Order, LocalID: {0} " + order.localId.ToString());
                        m_MainWindow.OrderViewModel.OnRtnOrder(order);
                    }
                    return;
            }
        }
    }
}
