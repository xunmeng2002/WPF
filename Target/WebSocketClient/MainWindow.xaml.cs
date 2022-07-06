using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebSocketClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            
        }
        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();
        private ClientWebSocket clientWebSocket = new ClientWebSocket();
        //private string address = "ws://127.0.0.1:10000";
        //private string address = "ws://192.168.137.129:9000";
        private string address = "ws://27.109.125.235:9000";
        private Uri? uri;
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

        private async void Connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                address = addressTextBox.Text;
                uri = new Uri(address);
                await Connect();
            }
            catch (Exception ex)
            {
                infoBlock.Text = ex.Message;
                ConnectStatus = clientWebSocket.State.ToString();
            }
        }
        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            if (clientWebSocket.State != WebSocketState.Open)
            {
                infoBlock.Text = "Send Failed. Please Check Connect Status.";
                return;
            }
            ReqOrder reqOrder = GeneratorReqOrder();
            AddOrderFromReqOrder(reqOrder);
            string msg = JsonSerializer.Serialize(reqOrder);
            sendContentBox.Text = msg;
            await Send(msg);
        }
        private ReqOrder GeneratorReqOrder()
        {
            ReqOrder reqOrder = new ReqOrder();
            reqOrder.type = "reqorder";
            reqOrder.customer = "customer";
            reqOrder.acctType = '1';
            reqOrder.investid = "A188800000";
            reqOrder.market = '1';
            reqOrder.securityId = securityTextBox.Text;
            reqOrder.isCancel = isCancelCheckBox.IsChecked == false ? '0' : '1';
            reqOrder.bsType = bsTypeCombBox.SelectedIndex == 0 ? '1' : '2';
            reqOrder.ordPrice = (int)(double.Parse(priceTextBox.Text) * 10000);
            reqOrder.ordQty = int.Parse(quantityTextBox.Text);
            reqOrder.ordType = priceTypeCombBox.SelectedIndex == 0 ? '1' : '2';
            return reqOrder;
        }
        private void AddOrderFromReqOrder(ReqOrder reqOrder)
        {
            Order order = new Order();
            order.type = "order";
            order.reqid = 0;
            order.envno = 0;
            order.customerId = reqOrder.customer;
            order.investid = reqOrder.investid;
            order.plotid = 0;
            order.localId = 0;
            order.market = reqOrder.market;
            order.securityId = reqOrder.securityId;
            order.ordPrice = reqOrder.ordPrice;
            order.ordQty = reqOrder.ordQty;
            order.tradeQty = 0;
            order.tradeAvgPx = 0;
            order.sendLocTime = 0;
            order.cnfLocTime = 0;
            order.sendTime = 0;
            order.cnfTime = 0;
            order.errorId = 0;
            order.errorMsg = "";
            Orders.Add(order);
        }


        public async Task Connect()
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
            infoBlock.Text = "Send Success.";
            await Recv();
        }
        public async Task Recv()
        {
            ConnectStatus = clientWebSocket.State.ToString();
            WebSocketReceiveResult webSocketReceiveResult = await clientWebSocket.ReceiveAsync(recvBuff, token);
            
            string msg = Encoding.UTF8.GetString(recvBuff, 0, webSocketReceiveResult.Count);
            recvContentBox.Text = msg;
            ParseBuff(msg);
        }
        private void ParseBuff(string msg)
        {
            JsonDocument jsonDocument = JsonDocument.Parse(msg);
            string? type = jsonDocument.RootElement.GetProperty("type").GetString();
            switch(type)
            {
                case "reqorder":
                    ReqOrder? reqOrder = jsonDocument.Deserialize<ReqOrder>();
                    infoBlock.Text = (reqOrder != null ? "Recv " : "Failed to Deserialize ") + type;
                    return;
                case "order":
                    Order? order = jsonDocument.Deserialize<Order>();
                    infoBlock.Text = (order != null ? "Recv " : "Failed to Deserialize ") + type;
                    if(order != null)
                    {
                        infoBlock.Text = "Recv Order, LocalID: {0} " + order.localId.ToString();
                        OnRtnOrder(order);
                    }
                    else
                    {
                        infoBlock.Text = "Failed to Deserialize Order";
                    }
                    return;

            }
        }
        private void OnRtnOrder(Order order)
        {
            List<Order> orders = Orders.Where(o => o.localId == order.localId).ToList();
            if(orders.Count > 0)
            {
                Order oldOrder = orders.First();
                UpdateOrder(oldOrder, order);
            }
            else
            {
                Orders.Add(order);
            }
        }
        private void UpdateOrder(Order oldOrder, Order newOrder)
        {
            oldOrder.reqid = newOrder.reqid;
            oldOrder.envno = newOrder.envno;
            oldOrder.customerId = newOrder.customerId;
            oldOrder.investid = newOrder.investid;
            oldOrder.plotid = newOrder.plotid;
            oldOrder.localId = newOrder.localId;
            oldOrder.market = newOrder.market;
            oldOrder.securityId = newOrder.securityId;
            oldOrder.ordQty = newOrder.ordQty;
            oldOrder.ordPrice = newOrder.ordPrice;
            oldOrder.tradeQty = newOrder.tradeQty;
            oldOrder.tradeAvgPx = newOrder.tradeAvgPx;
            oldOrder.sendLocTime = newOrder.sendLocTime;
            oldOrder.cnfLocTime = newOrder.cnfLocTime;
            oldOrder.sendTime = newOrder.sendTime;
            oldOrder.cnfTime = newOrder.cnfTime;
            oldOrder.errorId = newOrder.errorId;
            oldOrder.errorMsg = newOrder.errorMsg;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
