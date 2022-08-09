using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows;
using WebSocketClient.Mdb;
using WebSocketClient.Xmans;

namespace WebSocketClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow(ILogger<MainWindow> logger, MdbEngine mdbEngine, WebSocket webSocket, Config config)
        {
            InitializeComponent();
            Logger = logger;
            MdbEngine = mdbEngine;
            WebSocket = webSocket;
            Config = config;
            Address = Config.ServerAddress;            
            InitBindingData();
        }
        private void InitBindingData()
        {
            mainGrid.DataContext = this;
            dataGridBasketStrategy.ItemsSource = MdbEngine.BasketStrategyViewModel.BasketStrategys;
            dataGridPosition.ItemsSource = MdbEngine.PositionViewModel.Positions;
            dataGridOrder.ItemsSource = MdbEngine.OrderViewModel.Orders;
            dataGridTrade.ItemsSource = MdbEngine.TradeViewModel.Trades;
            statusBlock.DataContext = MdbEngine;
        }
        private ILogger<MainWindow> Logger { get; set; }
        public MdbEngine MdbEngine { get; set; }
        private Config Config { get; set; }
        

        private WebSocket WebSocket;
        private Uri? uri;
        private string address = "ws://127.0.0.1:10000";
        //private string address = "ws://192.168.137.129:9000";
        //private string address = "ws://27.109.125.235:9000";
        public string Address
        {
            get => address;
            set
            {
                if (address == value)
                    return;
                address = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private long maxRequestID;
        public long MaxRequestID 
        { 
            get
            {
                ++maxRequestID;
                return maxRequestID;
            }
        }
        public long SessionID { get; set; }

        private async void Connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                address = addressTextBox.Text;
                uri = new Uri(Config.ServerAddress);
                await WebSocket.Connect(uri);
            }
            catch (Exception ex)
            {
                infoBlock.Text = ex.Message;
                WebSocket.UpdateConnectStatus();
                MessageBox.Show(infoBlock.Text);
            }
        }
        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            if (WebSocket.ClientWebSocket.State != WebSocketState.Open)
            {
                infoBlock.Text = "Send Failed. Please Check Connect Status.";
                return;
            }
            ReqOrder reqOrder = GeneratorReqOrder();
            AddOrder(reqOrder);
            string msg = JsonSerializer.Serialize(reqOrder);
            await WebSocket.Send(msg);
            sendContentBox.Text = msg;
            infoBlock.Text = "Send Success.";
        }
        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            ReqLogin reqLogin = new ReqLogin();
            reqLogin.msgtype = "ReqLogin";
            reqLogin.reqid = MaxRequestID;

            ReqLoginField reqLoginField = new ReqLoginField();
            reqLoginField.userName = "xunmeng";
            reqLoginField.password = "123456";
            reqLogin.data.Add(reqLoginField);

            string msg = JsonSerializer.Serialize(reqLogin);
            await WebSocket.Send(msg);
            sendContentBox.Text = msg;
            infoBlock.Text = "Send Success.";
        }
        private ReqOrder GeneratorReqOrder()
        {
            ReqOrder reqOrder = new ReqOrder();
            reqOrder.msgtype = "ReqOrder";
            reqOrder.reqid = MaxRequestID;

            ReqOrderField reqOrderField = new ReqOrderField();
            reqOrderField.customerId = "";
            reqOrderField.frontId = reqOrder.reqid;
            reqOrderField.acctType = 0;
            reqOrderField.investId = "";
            reqOrderField.market = 0;
            reqOrderField.securityId = securityTextBox.Text;
            reqOrderField.bsType = bsTypeCombBox.SelectedIndex;
            reqOrderField.isCancel = 0;
            reqOrderField.ordType = 0;
            reqOrderField.ordQty = int.Parse(volumeTextBox.Text);
            reqOrderField.ordPrice = (int)(double.Parse(priceTextBox.Text) * 10000);
            reqOrderField.orgLocalId = 0;
            reqOrderField.orgOrdId = 0;
            reqOrder.data.Add(reqOrderField);

            return reqOrder;
        }
        private void AddOrder(ReqOrder reqOrder)
        {
            ReqOrderField reqOrderField = reqOrder.data[0];
            Order order = new Order();
            order.AccountID = reqOrderField.customerId;
            order.ExchangeID = reqOrderField.market.ToString();
            order.InstrumentID = reqOrderField.securityId;
            order.Direction = (Direction)reqOrderField.bsType;
            order.OrderPriceType = (OrderPriceType)reqOrderField.ordType;
            order.Price = ((double)reqOrderField.ordPrice) / 10000;
            order.Volume = reqOrderField.ordQty;
            order.VolumeTraded = 0;
            order.OrderStatus = OrderStatus.Inserting;
            order.RequestID = reqOrderField.frontId;
            order.SessionID = SessionID;
            order.InsertDate = DateTime.Now.ToString("yyyyMMdd");
            order.InsertTime = DateTime.Now.ToString("HH:mm:ss");
            order.ErrorID = 0;
            order.ErrorMsg = "";

            MdbEngine.OrderViewModel.Add(order);
        }

        public void OnStatusMsg(string statusMsg)
        {
            infoBlock.Text = statusMsg;
        }
        public void OnRecv(string msg)
        {
            recvContentBox.Text = msg;
        }
    }
}
