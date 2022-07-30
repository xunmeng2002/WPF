using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketClient.Mdb
{
    public class MdbEngine : PropertyChangedNotify
    {
        public MdbEngine(ILogger<MdbEngine> logger)
        {
            Logger = logger;
        }
        private ILogger<MdbEngine> Logger { get; set; }
        public OrderViewModel OrderViewModel { get; set; } = new OrderViewModel();
        public TradeViewModel TradeViewModel { get; set; } = new TradeViewModel();
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
            Logger.LogInformation("OnConnected");
            Status = "Connect";
        }
        public void OnDisconnected()
        {
            Logger.LogInformation("OnDisconnected");
            Status = "DisConnect";
        }
        public void OnLogin()
        {
            Logger.LogInformation("OnLogin");
            Status = "Login";
        }
        public void OnLogout()
        {
            Logger.LogInformation("OnLogout");
            Status = "Logout";
        }

        public void OnRtnOrder(Order order)
        {
            Logger.LogInformation("OnRtnOrder");

            List<Order> orders = OrderViewModel.Orders.Where(o => o.OrderLocalID == order.OrderLocalID).ToList();
            if (orders.Count == 0)
            {
                orders = OrderViewModel.Orders.Where(o => o.OrderSysID == order.OrderSysID).ToList();
            }
            if (orders.Count == 0)
            {
                OrderViewModel.Add(order);
            }
            else
            {
                Order oldOrder = orders.First();
                oldOrder.OrderSysID = order.OrderSysID;
                oldOrder.OrderPriceType = order.OrderPriceType;
                oldOrder.Price = order.Price;
                oldOrder.Volume = order.Volume;
                oldOrder.VolumeTraded = order.VolumeTraded;
                oldOrder.OrderStatus = order.OrderStatus;
                oldOrder.InsertDate = order.InsertDate;
                oldOrder.InsertTime = order.InsertTime;
                oldOrder.ErrorID = order.ErrorID;
                oldOrder.ErrorMsg = order.ErrorMsg;
            }
        }
        public void OnRtnTrade(Trade trade)
        {
            Logger.LogInformation("OnRtnTrade");
            List<Trade> trades = TradeViewModel.Trades.Where(t => t.OrderSysID == trade.OrderSysID && t.TradeID == trade.TradeID).ToList();
            if (trades.Count == 0)
            {
                TradeViewModel.Add(trade);
            }
        }
    }
}
