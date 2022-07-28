using OfferCommonLibrary.Mdb;
using QuickFix.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CmeQuickFixOffer.CmeCommon
{
    public class CmeEnumTransfer
    {
        public static char ToFixDirection(Direction direction)
        {
            if (direction == Direction.Buy)
                return Side.BUY;
            return Side.SELL;
        }
        public static char ToFixOrdType(OrderPriceType orderPriceType)
        {
            switch (orderPriceType)
            {
                case OrderPriceType.Anyprice:
                    return OrdType.MARKET;
                case OrderPriceType.LimitPrice:
                    return OrdType.LIMIT;
            }
            return OrdType.LIMIT;
        }
        public static char ToFixOrderStatus(OrderStatus orderStatus)
        {
            switch (orderStatus)
            {
                case OrderStatus.Inserting:
                    return OrdStatus.NEW;
                case OrderStatus.Inserted:
                    return OrdStatus.NEW;
                case OrderStatus.PartTraded:
                    return OrdStatus.PARTIALLY_FILLED;
                case OrderStatus.AllTraded:
                    return OrdStatus.FILLED;
                case OrderStatus.Canceled:
                    return OrdStatus.CANCELED;
                case OrderStatus.PartTradedCanceled:
                    return OrdStatus.CANCELED;
                case OrderStatus.Error:
                    return OrdStatus.REJECTED;
            }
            return OrdStatus.REJECTED;
        }
        public static char ToFixTimeInForce(TimeCondition timeCondition)
        {
            switch (timeCondition)
            {
                case TimeCondition.IOC:
                    return TimeInForce.IMMEDIATE_OR_CANCEL;
                case TimeCondition.GFS:
                    return TimeInForce.DAY;
                case TimeCondition.GFD:
                    return TimeInForce.DAY;
                case TimeCondition.GTD:
                    return TimeInForce.GOOD_TILL_DATE;
                case TimeCondition.GTC:
                    return TimeInForce.GOOD_TILL_CANCEL;
                case TimeCondition.GFA:
                    return TimeInForce.AT_THE_OPENING;
            }
            return TimeInForce.DAY;
        }

        public static Direction FromFixDirection(char direction)
        {
            if (direction == Side.BUY)
                return Direction.Buy;
            return Direction.Sell;
        }
        public static OrderPriceType FromFixOrdType(char orderType)
        {
            switch (orderType)
            {
                case OrdType.MARKET:
                    return OrderPriceType.Anyprice;
                case OrdType.LIMIT:
                    return OrderPriceType.LimitPrice;
            }
            return OrderPriceType.LimitPrice;
        }
        public static OrderStatus FromFixOrderStatus(char orderStatus)
        {
            switch (orderStatus)
            {
                case OrdStatus.PENDING_NEW:
                    return OrderStatus.Inserting;
                case OrdStatus.NEW:
                    return OrderStatus.Inserted;
                case OrdStatus.PARTIALLY_FILLED:
                    return OrderStatus.PartTraded;
                case OrdStatus.FILLED:
                    return OrderStatus.AllTraded;
                case OrdStatus.CANCELED:
                    return OrderStatus.Canceled;
                case OrdStatus.REJECTED:
                    return OrderStatus.Error;
            }
            return OrderStatus.Unknown;
        }
        public static TimeCondition FromFixTimeInForce(char timeInForce)
        {
            switch (timeInForce)
            {
                case TimeInForce.IMMEDIATE_OR_CANCEL:
                    return TimeCondition.IOC;
                case TimeInForce.DAY:
                    return TimeCondition.GFD;
                case TimeInForce.GOOD_TILL_DATE:
                    return TimeCondition.GTD;
                case TimeInForce.GOOD_TILL_CANCEL:
                    return TimeCondition.GTC;
                case TimeInForce.AT_THE_OPENING:
                    return TimeCondition.GFA;
            }
            return TimeCondition.GFD;
        }
    }
}
