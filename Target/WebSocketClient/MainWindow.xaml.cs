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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            webSocket = new WebSocket(this);
            Init();
        }
        private void Init()
        {
            InitViewModel();
        }
        private void InitViewModel()
        {
            OrderViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(OrderViewModel.IsAllOrderSelected) && sender != null)
                    orderCheckBox.IsChecked = ((OrderViewModel)sender).IsAllOrderSelected;
            };
        }
        public OrderViewModel OrderViewModel { get; set; } = new OrderViewModel();

        private WebSocket webSocket;
        private string address = "ws://127.0.0.1:10000";
        //private string address = "ws://192.168.137.129:9000";
        //private string address = "ws://27.109.125.235:9000";
        private Uri? uri;
        
        private async void Connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                address = addressTextBox.Text;
                uri = new Uri(address);
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
            reqOrder.type = "reqorder";
            reqOrder.customerId = "customer";
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
        public void AddOrderFromReqOrder(ReqOrder reqOrder)
        {
            Order order = new Order();
            order.type = "order";
            order.reqid = 0;
            order.envno = 0;
            order.customerId = reqOrder.customerId;
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

            OrderViewModel.AddOrder(order);
        }

        public void OnStatusMsg(string statusMsg)
        {
            infoBlock.Text = statusMsg;
        }
        public void OnRecv(string msg)
        {
            recvContentBox.Text = msg;
        }


        private void orderCheckBox_CheckedChange(object sender, RoutedEventArgs e)
        {
            OrderViewModel.IsAllOrderSelected = orderCheckBox.IsChecked;
        }
    }
}
