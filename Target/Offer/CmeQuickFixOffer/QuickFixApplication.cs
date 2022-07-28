using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmeQuickFixOffer.CmeCommon;
using Microsoft.Extensions.Logging;
using OfferCommonLibrary;
using OfferCommonLibrary.Mdb;
using QuickFix;
using QuickFix.Fields;
using QuickFix.FIX42;

namespace CmeQuickFixOffer
{
    public class QuickFixApplication : QuickFix.MessageCracker, QuickFix.IApplication, IMdbSubscribe
    {
        public QuickFixApplication(ILogger<QuickFixApplication> logger, MdbEngine mdbEngine, Config config)
        {
            Logger = logger;
            m_MdbEngine = mdbEngine;
            m_Config = config;
        }
        private ILogger<QuickFixApplication> Logger { get; }
        private IMdbInterface m_MdbEngine { get; }
        private Config m_Config { get; }

        public void Init(Config config, IInitiator initiator)
        {
            AppConfig = config;
            MyInitiator = initiator;
        }
        Session? m_Session = null;
        SessionID? m_SessionID;
        // This variable is a kludge for developer test purposes.  Don't do this on a production application.
        public IInitiator? MyInitiator;
        public Config AppConfig = new Config();

        #region IApplication interface overrides
        public void OnCreate(SessionID sessionID)
        {
            m_SessionID = sessionID;
            m_Session = Session.LookupSession(sessionID);
            m_Session.CheckCompID = false;
        }
        public void OnLogout(SessionID sessionID)
        {
            Logger.LogInformation("Logout - " + sessionID.ToString());
            m_MdbEngine.OnLogout();
        }
        public void OnLogon(SessionID sessionID)
        {
            Logger.LogInformation("Logon - " + sessionID.ToString());
            m_MdbEngine.OnLogin();
        }

        public void FromAdmin(QuickFix.Message message, SessionID sessionID)
        {
            Logger.LogInformation("IN:  " + message.ToString());
            try
            {
                Crack(message, sessionID);
            }
            catch (Exception ex)
            {
                Logger.LogInformation("==Cracker exception==");
                Logger.LogInformation(ex.ToString());
                Logger.LogInformation(ex.StackTrace);
            }
        }
        public void ToAdmin(QuickFix.Message message, SessionID sessionID)
        {
            string msgType = message.Header.GetString(QuickFix.Fields.Tags.MsgType);
            if (msgType == QuickFix.FIX42.Logon.MsgType)
            {
                message.SetField(new QuickFix.Fields.ResetSeqNumFlag(false));
                message.Header.SetField(new QuickFix.Fields.SenderCompID(AppConfig.LoginSenderCompID));
                message.SetField(new QuickFix.Fields.StringField(1603, AppConfig.ApplicationSystemName));
                message.SetField(new QuickFix.Fields.StringField(1604, AppConfig.ApplicationSystemVersion));
                message.SetField(new QuickFix.Fields.StringField(1605, AppConfig.ApplicationSystemVendor));

                message.SetField(new QuickFix.Fields.IntField(354, AppConfig.AccessID.Length));
                message.SetField(new QuickFix.Fields.StringField(355, AppConfig.AccessID));
                message.SetField(new QuickFix.Fields.StringField(1400, AppConfig.EncryptedPasswordMethod));

                string canonicalReq = Crypto.GetCanonicalReq(message);
                string encodeHmac = Crypto.CalculateHMAC(AppConfig.SecretKey, canonicalReq);
                message.SetField(new QuickFix.Fields.IntField(1401, encodeHmac.Length));
                message.SetField(new QuickFix.Fields.StringField(1402, encodeHmac));
            }
            Logger.LogInformation("OUT:  " + message.ToString());
        }
        public void FromApp(QuickFix.Message message, SessionID sessionID)
        {
            Logger.LogInformation("IN:  " + message.ToString());
            try
            {
                Crack(message, sessionID);
            }
            catch (Exception ex)
            {
                Logger.LogInformation("==Cracker exception==");
                Logger.LogInformation(ex.ToString());
                Logger.LogInformation(ex.StackTrace);
            }
        }
        public void ToApp(QuickFix.Message message, SessionID sessionID)
        {
            try
            {
                bool possDupFlag = false;
                if (message.Header.IsSetField(QuickFix.Fields.Tags.PossDupFlag))
                {
                    possDupFlag = QuickFix.Fields.Converters.BoolConverter.Convert(
                        message.Header.GetString(QuickFix.Fields.Tags.PossDupFlag)); /// FIXME
                }
                if (possDupFlag)
                    throw new DoNotSend();
            }
            catch (FieldNotFoundException)
            { }
            Logger.LogInformation("OUT: " + message.ToString());
        }
        #endregion

        #region MessageCracker handlers
        public void OnMessage(QuickFix.FIX42.Heartbeat m, SessionID s)
        {
            Logger.LogInformation(m.ToString());
        }
        public void OnMessage(QuickFix.FIX42.TestRequest m, SessionID s)
        {
            Logger.LogInformation(m.ToString());
        }
        public void OnMessage(QuickFix.FIX42.ResendRequest m, SessionID s)
        {
            Logger.LogInformation(m.ToString());
        }
        public void OnMessage(QuickFix.FIX42.Reject m, SessionID s)
        {
            Logger.LogInformation(m.ToString());
        }
        public void OnMessage(QuickFix.FIX42.SequenceReset m, SessionID s)
        {
            Logger.LogInformation(m.ToString());
        }
        public void OnMessage(QuickFix.FIX42.Logon m, SessionID s)
        {
            Logger.LogInformation(m.ToString());
        }
        public void OnMessage(QuickFix.FIX42.Logout m, SessionID s)
        {
            Logger.LogInformation("Received Logout");
            if (m.IsSetField(QuickFix.Fields.Tags.NextExpectedMsgSeqNum))
            {
                int nextExpectedMsgSeqNum = m.GetInt(QuickFix.Fields.Tags.NextExpectedMsgSeqNum);
                if (m_Session != null)
                {
                    m_Session.NextSenderMsgSeqNum = nextExpectedMsgSeqNum;
                }
            }
        }
        public void OnMessage(QuickFix.FIX42.ExecutionReport m, SessionID s)
        {
            Logger.LogInformation("Received execution report");
            Order order = new Order();

            SenderCompID exchangeID = new SenderCompID();
            CmeInstrument? cmeInstrument = null;
            double factor = 1;
            if (m.Header.IsSetField(exchangeID))
            {
                m.Header.GetField(exchangeID);
            }
            if (m.IsSetSecurityDesc())
            {
                cmeInstrument = CmeInstrumentTransfer.GetFixInstrumentFromExchange(exchangeID.getValue(), m.SecurityDesc.getValue());
                factor = Commodity.GetCommodityPriceFactor(cmeInstrument.ExchangeID, cmeInstrument.ProductID);

                order.ExchangeID = cmeInstrument.ExchangeID;
                order.InstrumentID = cmeInstrument.InstrumentID;
            }
            order.AccountID = m.Account.getValue();
            if(m.IsSetOrigClOrdID())
            {
                order.OrderLocalID = m.OrigClOrdID.getValue();
            }
            else
            {
                order.OrderLocalID = m.ClOrdID.getValue();
            }
            order.OrderSysID = m.OrderID.getValue();
            order.Direction = CmeEnumTransfer.FromFixDirection(m.Side.getValue());

            order.OffsetFlag = OffsetFlag.Open;
            order.HedgeFlag = HedgeFlag.Speculation;
            order.OrderPriceType = CmeEnumTransfer.FromFixOrdType(m.OrdType.getValue());
            order.Price = (double)(m.Price.getValue())/factor;
            order.Volume = (int)(m.OrderQty.getValue());
            order.VolumeTraded = (int)(m.CumQty.getValue());
            order.OrderStatus = CmeEnumTransfer.FromFixOrderStatus(m.OrdStatus.getValue());
            order.StatusMsg = m.Text.getValue();
            order.RequestID = "";
            order.FrontID = "";
            order.SessionID = 0;

            var transactTime = m.TransactTime.getValue().ToLocalTime();
            if(order.OrderStatus == OrderStatus.Inserted)
            {
                order.InsertDate = transactTime.ToString("yyyyMMdd");
                order.InsertTime = transactTime.ToString("HH:mm:ss");
                order.ExchangeInsertDate = order.InsertDate;
                order.ExchangeInsertTime = order.InsertTime;
            }
            else if (order.OrderStatus == OrderStatus.Canceled)
            {
                order.CancelDate = transactTime.ToString("yyyyMMdd");
                order.CancelTime = transactTime.ToString("HH:mm:ss");
            }
            order.ForceCloseReason = ForceCloseReason.NotForceClose;
            order.IsLocalOrder = IsLocalOrder.Others;
            order.UserProductInfo = "";
            order.TimeCondition = CmeEnumTransfer.FromFixTimeInForce(m.TimeInForce.getValue());
            order.GTDDate = m.ExpireDate.getValue();
            order.MinVolume = (int)(m.MinQty.getValue());
            if (order.MinVolume == 0)
            {
                order.VolumeCondition = VolumeCondition.AV;
            }
            else if (order.MinVolume == order.Volume)
            {
                order.VolumeCondition = VolumeCondition.CV;
            }
            else
            {
                order.VolumeCondition = VolumeCondition.MV;
            }
            order.ContingentCondition = ContingentCondition.Immediately;
            order.StopPrice = (double)(m.StopPx.getValue());
            order.IsSwapOrder = 0;
            m_MdbEngine.OnRtnOrder(order);

            if(m.ExecType.getValue() == ExecType.PARTIAL_FILL || m.ExecType.getValue() == ExecType.FILL)
            {
                Trade trade = new Trade();
                trade.TradingDay = order.TradingDay;
                trade.AccountID = m.Account.getValue();
                if (cmeInstrument != null)
                {
                    trade.ExchangeID = cmeInstrument.ExchangeID;
                    trade.InstrumentID = cmeInstrument.InstrumentID;
                }
                StringField tradeID = new StringField(3711);
                if (m.IsSetField(tradeID))
                {
                    m.GetField(tradeID);
                    trade.TradeID = tradeID.getValue();
                }
                trade.Direction = CmeEnumTransfer.FromFixDirection(m.Side.getValue());
                trade.OffsetFlag = OffsetFlag.Open;
                trade.HedgeFlag = HedgeFlag.Speculation;
                trade.Price = (double)m.LastPx.getValue() / factor;
                trade.Volume = (int)m.LastShares.getValue();
                trade.OrderLocalID = order.OrderLocalID;
                trade.OrderSysID = order.OrderSysID;
                trade.TradeDate = transactTime.ToString("yyyyMMdd");
                trade.TradeTime = transactTime.ToString("HH:mm:ss");
                m_MdbEngine.OnRtnTrade(trade);
            }
        }

        public void OnMessage(QuickFix.FIX42.OrderCancelReject m, SessionID s)
        {
            Logger.LogInformation("Received order cancel reject");
        }

        public void OnMessage(QuickFix.FIX42.QuoteAcknowledgement m, SessionID s)
        {
            Logger.LogInformation(m.ToString());
        }

        public void ReqInsertOrder(Order order)
        {
            NewOrderSingle newOrderSingle = new NewOrderSingle();
            PrepareHeader(newOrderSingle.Header);

            var cmeInstrument = CmeInstrumentTransfer.GetFixInstrumentFromBroker(order.ExchangeID, order.InstrumentID);
            double factor = Commodity.GetCommodityPriceFactor(cmeInstrument.ExchangeID, cmeInstrument.ProductID);

            newOrderSingle.SetField(new ClOrdID(order.OrderLocalID));
            newOrderSingle.SetField(new OrigClOrdID(order.OrderLocalID));
            newOrderSingle.SetField(new HandlInst(HandlInst.AUTOMATED_EXECUTION_ORDER_PRIVATE_NO_BROKER_INTERVENTION));
            newOrderSingle.SetField(new OrderQty(order.Volume));
            newOrderSingle.SetField(new SecurityExchange(cmeInstrument.FixExchangeID));
            newOrderSingle.SetField(new StringField(454, "1"));
            newOrderSingle.SetField(new StringField(455, cmeInstrument.FixInstrumentID));
            newOrderSingle.SetField(new StringField(456, "98"));

            newOrderSingle.SetField(new Symbol(cmeInstrument.ProductID));
            newOrderSingle.SetField(new SecurityType("FUT"));
            newOrderSingle.SetField(new SecurityDesc(cmeInstrument.FixInstrumentID));
            newOrderSingle.SetField(new MaturityMonthYear(""));
            newOrderSingle.SetField(new Side(CmeEnumTransfer.ToFixDirection(order.Direction)));
            newOrderSingle.SetField(new TransactTime());
            newOrderSingle.SetField(new Account(m_Config.Account));
            newOrderSingle.SetField(new OrdType(CmeEnumTransfer.ToFixOrdType(order.OrderPriceType)));

            if(order.OrderPriceType != OrderPriceType.Anyprice)
            {
                newOrderSingle.SetField(new Price((decimal)(order.Price * factor)));
            }
            newOrderSingle.SetField(new MinQty(order.MinVolume));
            newOrderSingle.SetField(new CustOrderHandlingInst("Y"));
            newOrderSingle.SetField(new ManualOrderIndicator(false));
            newOrderSingle.SetField(new StringField(9702, "4"));
            newOrderSingle.SetField(new CustomerOrFirm(CustomerOrFirm.CUSTOMER));

            m_Session?.Send(newOrderSingle);
        }

        public void ReqInsertOrderCancel(OrderCancel orderCancel)
        {
            OrderCancelRequest orderCancelRequest = new OrderCancelRequest();
            PrepareHeader(orderCancelRequest.Header);
            var cmeInstrument = CmeInstrumentTransfer.GetFixInstrumentFromBroker(orderCancel.ExchangeID, orderCancel.InstrumentID);

            orderCancelRequest.SetField(new Account(m_Config.Account));
            orderCancelRequest.SetField(new ClOrdID(orderCancel.OrderLocalID));
            orderCancelRequest.SetField(new OrderID(orderCancel.OrderSysID));
            orderCancelRequest.SetField(new OrigClOrdID(orderCancel.OrigOrderLocalID));
            orderCancelRequest.SetField(new Side((char)orderCancel.Direction));
            orderCancelRequest.SetField(new Symbol(cmeInstrument.ProductID));
            orderCancelRequest.SetField(new TransactTime(DateTime.Now.ToUniversalTime()));
            orderCancelRequest.SetField(new StringField(1028, "Y"));
            orderCancelRequest.SetField(new SecurityDesc(cmeInstrument.FixInstrumentID));
            orderCancelRequest.SetField(new SecurityType("FUT"));
            orderCancelRequest.SetField(new StringField(9717, orderCancel.OrigOrderLocalID));

            m_Session?.Send(orderCancelRequest);
        }
        #endregion


        void PrepareHeader(QuickFix.Header header)
        {
            header.SetField(new BeginString(m_SessionID?.BeginString));
            header.SetField(new SenderCompID(m_SessionID?.SenderCompID));
            header.SetField(new TargetCompID(m_SessionID?.TargetCompID));
            header.SetField(new SenderLocationID(m_SessionID?.SenderLocationID));

            header.SetField(new SenderSubID(m_SessionID?.SenderSubID));
            header.SetField(new TargetSubID(m_SessionID?.TargetSubID));
        }
    }
}
