using Microsoft.Extensions.Logging;
using OfferCommonLibrary.Its;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCommonLibrary.Mdb
{
    public class MdbEngine : PropertyChangedNotify, IMdbInterface
    {
        public MdbEngine(ILogger<MdbEngine> logger, OrderViewModel orderViewModel, OrderCancelViewModel orderCancelViewModel, TradeViewModel tradeViewModel)
        {
            m_Logger = logger;
            m_OrderViewModel = orderViewModel;
            m_OrderCancelViewModel = orderCancelViewModel;
            m_TradeViewModel = tradeViewModel;

            AddOrder();
        }
        private ILogger<MdbEngine> m_Logger { get; set; }
        public OrderViewModel m_OrderViewModel { get; set; }
        public OrderCancelViewModel m_OrderCancelViewModel { get; set; }
        public TradeViewModel m_TradeViewModel { get; set; }
        private ItsEngine? m_ItsEngine { get; set; }
        private IMdbSubscribe m_MdbSubscribe { get; set; }

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

        
        private void AddOrder()
        {
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
            m_OrderViewModel.Orders.Add(order);
        }
        public void Init(ItsEngine? itsEngine, IMdbSubscribe mdbSubscribe)
        {
            m_ItsEngine = itsEngine;
            m_MdbSubscribe = mdbSubscribe;
        }

        public void InsertOrder(ItsInsertOrder itsInsertOrder)
        {

        }
        public void InsertOrderCancel(ItsInsertOrderCancel itsInsertOrder)
        {

        }


        public void OnConnected()
        {
            m_Logger.LogInformation("OnConnected");
            Status = "Connect";
        }
        public void OnDisconnected()
        {
            m_Logger.LogInformation("OnDisconnected");
            Status = "DisConnect";
        }
        public void OnLogin()
        {
            m_Logger.LogInformation("OnLogin");
            Status = "Login";
        }
        public void OnLogout()
        {
            m_Logger.LogInformation("OnLogout");
            Status = "Logout";
        }
        public void OnRtnOrder(Order order)
        {
            m_Logger.LogInformation("OnRtnOrder");

            List<Order> orders = m_OrderViewModel.Orders.Where(o => o.OrderLocalID == order.OrderLocalID).ToList();
            if (orders.Count == 0)
            {
                orders = m_OrderViewModel.Orders.Where(o => o.TradingDay == order.TradingDay && o.OrderSysID == order.OrderSysID).ToList();
            }
            if (orders.Count == 0)
            {
                m_OrderViewModel.Orders.Add(order);
            }
            else
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
        }
        public void OnRtnOrderCancel(OrderCancel orderCancel)
        {
            List<OrderCancel> orderCancels = m_OrderCancelViewModel.OrderCancels.Where(oc => oc.OrderLocalID == orderCancel.OrderLocalID).ToList();
            if (orderCancels.Count == 0)
            {
                m_OrderCancelViewModel.OrderCancels.Add(orderCancel);
            }
            else
            {
                OrderCancel oldOrderCancel = orderCancels.First();
                oldOrderCancel.ErrorID = orderCancel.ErrorID;
                oldOrderCancel.ErrorMsg = orderCancel.ErrorMsg;
            }
        }
        public void OnRtnTrade(Trade trade)
        {
            m_Logger.LogInformation("OnRtnTrade");
            List<Trade> trades = m_TradeViewModel.Trades.Where(t => t.TradingDay == trade.TradingDay && t.OrderSysID == trade.OrderSysID && t.TradeID == trade.TradeID).ToList();
            if (trades.Count == 0)
            {
                m_TradeViewModel.Trades.Add(trade);
            }
        }
    }
}
