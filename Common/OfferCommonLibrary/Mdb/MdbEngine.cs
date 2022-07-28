using CommonLibrary;
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
        public MdbEngine(ILogger<MdbEngine> logger, OrderSequenceViewModel orderSequenceViewModel, OrderViewModel orderViewModel, OrderCancelViewModel orderCancelViewModel, TradeViewModel tradeViewModel)
        {
            m_Logger = logger;
            m_OrderSequenceViewModel = orderSequenceViewModel;
            m_OrderViewModel = orderViewModel;
            m_OrderCancelViewModel = orderCancelViewModel;
            m_TradeViewModel = tradeViewModel;
            AddOrder();
        }
        private ILogger<MdbEngine> m_Logger { get; set; }
        public OrderSequenceViewModel m_OrderSequenceViewModel { get; set; }
        public OrderViewModel m_OrderViewModel { get; set; }
        public OrderCancelViewModel m_OrderCancelViewModel { get; set; }
        public TradeViewModel m_TradeViewModel { get; set; }
        private ItsEngine? m_ItsEngine { get; set; }
        private IMdbSubscribe? m_MdbSubscribe { get; set; }
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

        public void InsertOrder(UserToken userToken, ItsInsertOrder itsInsertOrder)
        {
            Order order = new Order();
            order.TradingDay = GetLocalDate();
            order.AccountID = itsInsertOrder.AccountID;
            order.ExchangeID = itsInsertOrder.ExchangeID;
            order.InstrumentID = itsInsertOrder.InstrumentID;
            order.OrderLocalID = GetNextOrderLocalID(itsInsertOrder.TradingDay);
            order.OrderSysID = "";
            order.Direction = MdbConvertEnums.ConvertToDirection(itsInsertOrder.Direction);
            order.OffsetFlag = OffsetFlag.Open;
            order.HedgeFlag = HedgeFlag.Speculation;
            order.OrderPriceType = MdbConvertEnums.ConvertToOrderPriceType(itsInsertOrder.OrderPriceType);
            order.Price = double.Parse(itsInsertOrder.Price);
            order.Volume = int.Parse(itsInsertOrder.Volume);
            order.VolumeTraded = 0;
            order.OrderStatus = OrderStatus.Inserting;
            order.RequestID = itsInsertOrder.RequestID;
            order.FrontID = "";
            order.SessionID = userToken.SessionID;
            order.InsertDate = itsInsertOrder.TradingDay;
            order.InsertTime = GetLocalTime();
            order.ExchangeInsertDate = "";
            order.ExchangeInsertTime = "";
            order.CancelDate = "";
            order.CancelTime = "";
            order.ForceCloseReason = ForceCloseReason.NotForceClose;
            order.IsLocalOrder = IsLocalOrder.Local;
            order.TimeCondition = MdbConvertEnums.ConvertToTimeCondition(itsInsertOrder.TimeCondition);
            order.GTDDate = "";
            order.VolumeCondition = MdbConvertEnums.ConvertToVolumeCondition(itsInsertOrder.VolumeCondition);
            order.MinVolume = int.Parse(itsInsertOrder.MinVolume);
            order.ContingentCondition = ContingentCondition.Immediately;
            order.StopPrice = 0.0;
            order.IsSwapOrder = 0;

            m_OrderViewModel.Orders.Add(order);
            m_MdbSubscribe?.ReqInsertOrder(order);
            SendResponse(userToken, itsInsertOrder.SequenceNo);
        }
        public void InsertOrderCancel(UserToken userToken, ItsInsertOrderCancel itsInsertOrderCancel)
        {
            Order? order = GetOrder(itsInsertOrderCancel.BrokerOrderID, itsInsertOrderCancel.TradingDay, itsInsertOrderCancel.OrderSysID);
            if(order == null)
            {
                string errorMsg = string.Format($"找不到报单，委托日期:{itsInsertOrderCancel.TradingDay}, 交易所报单编号:{itsInsertOrderCancel.BrokerOrderID}，经纪公司报单编号:{itsInsertOrderCancel.OrderSysID}");
                SendResponse(userToken, itsInsertOrderCancel.SequenceNo, -1, errorMsg);
                m_Logger.LogWarning(errorMsg);
            }
            else
            {
                OrderCancel orderCancel = new OrderCancel();
                orderCancel.TradingDay = GetLocalDate();
                orderCancel.AccountID = "";
                orderCancel.ExchangeID = itsInsertOrderCancel.ExchangeID;
                orderCancel.InstrumentID = itsInsertOrderCancel.InstrumentID;
                orderCancel.OrderLocalID = GetNextOrderLocalID(itsInsertOrderCancel.TradingDay);
                orderCancel.OrigOrderLocalID = order.OrderLocalID;
                orderCancel.OrderSysID = order.OrderSysID;
                orderCancel.Direction = MdbConvertEnums.ConvertToDirection(itsInsertOrderCancel.Direction);
                orderCancel.OrderRef = itsInsertOrderCancel.OrderRef;
                orderCancel.FrontID = itsInsertOrderCancel.FrontID;
                orderCancel.SessionID = long.Parse(itsInsertOrderCancel.SessionID);
                orderCancel.ErrorID = 0;
                orderCancel.ErrorMsg = "";
                orderCancel.InsertDate = itsInsertOrderCancel.TradingDay;
                orderCancel.CancelDate = GetLocalDate();

                m_OrderCancelViewModel.OrderCancels.Add(orderCancel);
                m_MdbSubscribe?.ReqInsertOrderCancel(orderCancel);
                SendResponse(userToken, itsInsertOrderCancel.SequenceNo);
            }
        }

        public Order? GetOrder(string orderLocalID, string tradingDay, string orderSysID)
        {
            Order? order = null;
            if (orderLocalID != "")
            {
                order = m_OrderViewModel.Orders.Where(order => order.OrderLocalID == orderLocalID).FirstOrDefault();
            }
            if (order == null && tradingDay != null && orderSysID != null)
            {
                order = m_OrderViewModel.Orders.Where(order => order.TradingDay == tradingDay && order.OrderSysID == orderSysID).FirstOrDefault();
            }
            return order;
        }
        private void SendResponse(UserToken userToken, string sequenceNo, int errorID = 0, string errorMsg = "")
        {
            ItsRspOrder itsRspOrder = new ItsRspOrder();
            itsRspOrder.SequenceNo = sequenceNo;
            itsRspOrder.Reserve1 = "1";
            itsRspOrder.Reserve2 = "0";
            itsRspOrder.ErrorID = errorID.ToString();
            itsRspOrder.ErrorMsg = errorMsg;

            m_ItsEngine?.Send(userToken, itsRspOrder.ToString());
        }
        private string GetNextOrderLocalID(string tradingDay)
        {
            var orderSequences = m_OrderSequenceViewModel.OrderSequences.Where(orderSequence => orderSequence.TradingDay == tradingDay);
            if (orderSequences.Any())
            {
                var orderSequence = orderSequences.First();
                return (++orderSequence.MaxOrderLocalID).ToString();
            }
            else
            {
                var orderSequence = new OrderSequence();
                orderSequence.TradingDay = tradingDay;
                orderSequence.MaxOrderLocalID = 1;
                m_OrderSequenceViewModel.OrderSequences.Add(orderSequence);
                return orderSequence.MaxOrderLocalID.ToString();
            }
        }
        private string GetLocalDate()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }
        private string GetLocalTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
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


                ItsOrder itsOrder = new ItsOrder();
                itsOrder.ChannelID = m_ItsEngine.m_ChannelID.ToString();
                itsOrder.ExchangeID = order.ExchangeID;
                itsOrder.InstrumentID = order.InstrumentID;
                itsOrder.OrderRef = "";
                itsOrder.InsertTime = order.InsertTime;
                itsOrder.CancelTime = order.CancelTime;
                itsOrder.OrderSysID = order.OrderSysID;
                itsOrder.StatusMsg = order.StatusMsg;
                itsOrder.Direction = ((int)order.Direction).ToString();
                itsOrder.CombOffsetFlag = ((int)order.OffsetFlag).ToString();
                itsOrder.CombHedgeFlag = ((int)order.HedgeFlag).ToString();
                itsOrder.OrderPriceType = ((int)order.OrderPriceType).ToString();
                itsOrder.OrderStatus = ((int)order.OrderStatus).ToString();
                itsOrder.ForceCloseReason = ((int)order.ForceCloseReason).ToString();
                itsOrder.RequestID = order.RequestID;
                itsOrder.FrontID = order.FrontID;
                itsOrder.SessionID = order.SessionID.ToString();
                itsOrder.BrokerOrderID = order.OrderLocalID;
                itsOrder.VolumeTotalOriginal = order.Volume.ToString();
                itsOrder.VolumeTraded = order.VolumeTraded.ToString();
                itsOrder.InsertDate = order.InsertDate;
                itsOrder.TradingDay = order.InsertDate;
                itsOrder.LimitPrice = order.Price.ToString();
                itsOrder.IsLocalOrder = ((int)order.IsLocalOrder).ToString();
                itsOrder.UserProductInfo = order.UserProductInfo;
                itsOrder.TimeCondition = ((int)order.TimeCondition).ToString();
                itsOrder.GTDDate = order.GTDDate;
                itsOrder.VolumeCondition = ((int)order.VolumeCondition).ToString();
                itsOrder.MinVolume = order.MinVolume.ToString();
                itsOrder.ContingentCondition = ((int)order.ContingentCondition).ToString();
                itsOrder.StopPrice = order.StopPrice.ToString();
                itsOrder.IsSwapOrder = order.IsSwapOrder.ToString();
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
