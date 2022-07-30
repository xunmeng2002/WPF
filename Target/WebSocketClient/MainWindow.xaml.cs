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
        public MainWindow(ILogger<MainWindow> logger, MdbEngine mdbEngine, Config config)
        {
            InitializeComponent();
            Logger = logger;
            MdbEngine = mdbEngine;
            Config = config;

            Address = Config.ServerAddress;

            webSocket = new WebSocket(this);
            InitBindingData();
        }
        private void InitBindingData()
        {
            mainGrid.DataContext = this;
            dataGridOrder.ItemsSource = MdbEngine.OrderViewModel.Orders;
            dataGridTrade.ItemsSource = MdbEngine.TradeViewModel.Trades;
            statusBlock.DataContext = MdbEngine;
        }
        private ILogger<MainWindow> Logger { get; set; }
        public MdbEngine MdbEngine { get; set; }
        private Config Config { get; set; }
        

        private WebSocket webSocket;
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

        private async void Connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                address = addressTextBox.Text;
                uri = new Uri(Config.ServerAddress);
                await webSocket.Connect(uri);
            }
            catch (Exception ex)
            {
                infoBlock.Text = ex.Message;
                webSocket.UpdateConnectStatus();
                MessageBox.Show(infoBlock.Text);
            }
        }
        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            if (webSocket.clientWebSocket.State != WebSocketState.Open)
            {
                infoBlock.Text = "Send Failed. Please Check Connect Status.";
                return;
            }
            ReqOrder reqOrder = GeneratorReqOrder();
            string msg = JsonSerializer.Serialize(reqOrder);
            await webSocket.Send(msg);
            //AddOrderFromReqOrder(reqOrder);
            sendContentBox.Text = msg;
            infoBlock.Text = "Send Success.";
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {

        }
        private ReqOrder GeneratorReqOrder()
        {
            ReqOrder reqOrder = new ReqOrder();
            reqOrder.msgtype = "ReqOrder";
            reqOrder.reqid = 1;
            return reqOrder;
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
