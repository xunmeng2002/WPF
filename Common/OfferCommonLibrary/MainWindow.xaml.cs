using Microsoft.Extensions.Logging;
using OfferCommonLibrary.Mdb;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OfferCommonLibrary
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged, IMdbInterface
    {
        public MainWindow(ILogger<MainWindow> logger)
        {
            InitializeComponent();
            Logger = logger;
            var order = new Order();
            order.TradingDay = "20220715";
            order.AccountID = "123456";
            order.ExchangeID = "CME";
            order.InstrumentID = "CL2212";
            order.OrderLocalID = "220715000001";
            order.OrderSysID = "123456";
            order.Direction = Direction.Sell;
            order.OffsetFlag = OffsetFlag.Open;
            order.HedgeFlag = HedgeFlag.Hedge;
            order.OrderPriceType = OrderPriceType.LimitPrice;
            order.Price = 100.05;
            order.Volume = 5;
            order.VolumeTraded = 1;
            order.OrderStatus = OrderStatus.PartTraded;
            order.ErrorID = 0;
            order.ErrorMsg = string.Empty;
            order.StatusMsg = string.Empty;
            order.RequestID = "1";
            order.FrontID = "1";
            order.SessionID = 1;
            order.InsertDate = "20220715";
            order.InsertTime = "16:52:11";
            order.ExchangeInsertDate = "20220715";
            order.ExchangeInsertTime = "16:52:11";
            order.CancelDate = "";
            order.CancelTime = "";
            order.ForceCloseReason = ForceCloseReason.NotForceClose;
            order.IsLocalOrder = IsLocalOrder.Local;
            order.UserProductInfo = "";
            order.TimeCondition = TimeCondition.GFD;
            order.GTDDate = "";
            order.VolumeCondition = VolumeCondition.AV;
            order.ContingentCondition = ContingentCondition.Immediately;
            order.StopPrice = 0;
            order.IsSwapOrder = 0;
            Orders.Add(order);
        }
        public ILogger<MainWindow> Logger { get; set; }

        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();
        public ObservableCollection<Trade> Trades { get; set; } = new ObservableCollection<Trade>();
        public ObservableCollection<OrderCancel> OrderCancels { get; set; } = new ObservableCollection<OrderCancel>();

        private string status = "None";
        public string Status
        {
            get => status;
            set
            {
                if (status == value)
                    return;
                status = value;
                OnPropertyChanged();
            }
        }

        public void OnConnected()
        {
            Status = "Connect";
        }
        public void OnDisconnected()
        {
            Status = "DisConnect";
        }
        public void OnLogin()
        {
            Status = "Login";
        }
        public void OnLogout()
        {
            Status = "Logout";
        }
        public void OnRtnOrder(Order order)
        {
            Dispatcher.BeginInvoke(UpdateOrder, order);
        }
        public void OnRtnTrade(Trade trade)
        {
            Dispatcher.BeginInvoke(UpdateTrade, trade);
        }
        public void OnErrRtnOrderCancel(OrderCancel orderCancel)
        {
            Dispatcher.BeginInvoke(UpdateOrderCancel, orderCancel);
        }
        private void UpdateOrder(Order order)
        {
            List<Order> orders = Orders.Where(o => o.OrderLocalID == order.OrderLocalID).ToList();
            if (orders.Count == 0)
            {
                orders = Orders.Where(o => o.TradingDay == order.TradingDay && o.OrderSysID == order.OrderSysID).ToList();
            }
            if (orders.Count == 0)
            {
                Order oldOrder = orders.First();
                oldOrder.ErrorID = order.ErrorID;
                oldOrder.ErrorMsg = order.ErrorMsg;
                oldOrder.StatusMsg = order.StatusMsg;
                oldOrder.ExchangeInsertDate = order.ExchangeInsertDate;
                oldOrder.ExchangeInsertTime = order.ExchangeInsertTime;
                oldOrder.CancelDate = order.CancelDate;
                oldOrder.CancelTime = order.CancelTime;
                oldOrder.IsLocalOrder = IsLocalOrder.Local;
            }
            else
            {
                Orders.Add(order);
            }
        }
        private void UpdateTrade(Trade trade)
        {
            List<Trade> trades = Trades.Where(t => t.TradingDay == trade.TradingDay && t.OrderSysID == trade.OrderSysID && t.TradeID == trade.TradeID).ToList();
            if (trades.Count == 0)
            {
                Trades.Add(trade);
            }
        }
        private void UpdateOrderCancel(OrderCancel orderCancel)
        {
            List<OrderCancel> orderCancels = OrderCancels.Where(oc => oc.OrderLocalID == orderCancel.OrderLocalID).ToList();
            if(orderCancels.Count != 0)
            {
                OrderCancel oldOrderCancel = orderCancels.First();
                oldOrderCancel.ErrorID = orderCancel.ErrorID;
                oldOrderCancel.ErrorMsg = orderCancel.ErrorMsg;
            }
            else
            {
                OrderCancels.Add(orderCancel);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

