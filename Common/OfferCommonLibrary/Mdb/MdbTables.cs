using System;

namespace OfferCommonLibrary.Mdb
{
	public class OrderSequence : PropertyChangedNotify
	{
		private string tradingDay = string.Empty;
		private int maxOrderLocalID;

		public string TradingDay
		{
			get => tradingDay;
			set
			{
				if (tradingDay == value)
					return;
				tradingDay = value;
				OnPropertyChanged();
			}
		}
		public int MaxOrderLocalID
		{
			get => maxOrderLocalID;
			set
			{
				if (maxOrderLocalID == value)
					return;
				maxOrderLocalID = value;
				OnPropertyChanged();
			}
		}
	}
	public class Order : PropertyChangedNotify
	{
		private string tradingDay = string.Empty;
		private string accountID = string.Empty;
		private string exchangeID = string.Empty;
		private string instrumentID = string.Empty;
		private string orderLocalID = string.Empty;
		private string orderSysID = string.Empty;
		private Direction direction;
		private OffsetFlag offsetFlag;
		private HedgeFlag hedgeFlag;
		private OrderPriceType orderPriceType;
		private double price;
		private int volume;
		private int volumeTraded;
		private OrderStatus orderStatus;
		private int errorID;
		private string errorMsg = string.Empty;
		private string statusMsg = string.Empty;
		private string requestID = string.Empty;
		private string frontID = string.Empty;
		private int sessionID;
		private string insertDate = string.Empty;
		private string insertTime = string.Empty;
		private string exchangeInsertDate = string.Empty;
		private string exchangeInsertTime = string.Empty;
		private string cancelDate = string.Empty;
		private string cancelTime = string.Empty;
		private ForceCloseReason forceCloseReason;
		private IsLocalOrder isLocalOrder;
		private string userProductInfo = string.Empty;
		private TimeCondition timeCondition;
		private string gTDDate = string.Empty;
		private VolumeCondition volumeCondition;
		private int minVolume;
		private ContingentCondition contingentCondition;
		private double stopPrice;
		private int isSwapOrder;

		public string TradingDay
		{
			get => tradingDay;
			set
			{
				if (tradingDay == value)
					return;
				tradingDay = value;
				OnPropertyChanged();
			}
		}
		public string AccountID
		{
			get => accountID;
			set
			{
				if (accountID == value)
					return;
				accountID = value;
				OnPropertyChanged();
			}
		}
		public string ExchangeID
		{
			get => exchangeID;
			set
			{
				if (exchangeID == value)
					return;
				exchangeID = value;
				OnPropertyChanged();
			}
		}
		public string InstrumentID
		{
			get => instrumentID;
			set
			{
				if (instrumentID == value)
					return;
				instrumentID = value;
				OnPropertyChanged();
			}
		}
		public string OrderLocalID
		{
			get => orderLocalID;
			set
			{
				if (orderLocalID == value)
					return;
				orderLocalID = value;
				OnPropertyChanged();
			}
		}
		public string OrderSysID
		{
			get => orderSysID;
			set
			{
				if (orderSysID == value)
					return;
				orderSysID = value;
				OnPropertyChanged();
			}
		}
		public Direction Direction
		{
			get => direction;
			set
			{
				if (direction == value)
					return;
				direction = value;
				OnPropertyChanged();
			}
		}
		public OffsetFlag OffsetFlag
		{
			get => offsetFlag;
			set
			{
				if (offsetFlag == value)
					return;
				offsetFlag = value;
				OnPropertyChanged();
			}
		}
		public HedgeFlag HedgeFlag
		{
			get => hedgeFlag;
			set
			{
				if (hedgeFlag == value)
					return;
				hedgeFlag = value;
				OnPropertyChanged();
			}
		}
		public OrderPriceType OrderPriceType
		{
			get => orderPriceType;
			set
			{
				if (orderPriceType == value)
					return;
				orderPriceType = value;
				OnPropertyChanged();
			}
		}
		public double Price
		{
			get => price;
			set
			{
				if (price == value)
					return;
				price = value;
				OnPropertyChanged();
			}
		}
		public int Volume
		{
			get => volume;
			set
			{
				if (volume == value)
					return;
				volume = value;
				OnPropertyChanged();
			}
		}
		public int VolumeTraded
		{
			get => volumeTraded;
			set
			{
				if (volumeTraded == value)
					return;
				volumeTraded = value;
				OnPropertyChanged();
			}
		}
		public OrderStatus OrderStatus
		{
			get => orderStatus;
			set
			{
				if (orderStatus == value)
					return;
				orderStatus = value;
				OnPropertyChanged();
			}
		}
		public int ErrorID
		{
			get => errorID;
			set
			{
				if (errorID == value)
					return;
				errorID = value;
				OnPropertyChanged();
			}
		}
		public string ErrorMsg
		{
			get => errorMsg;
			set
			{
				if (errorMsg == value)
					return;
				errorMsg = value;
				OnPropertyChanged();
			}
		}
		public string StatusMsg
		{
			get => statusMsg;
			set
			{
				if (statusMsg == value)
					return;
				statusMsg = value;
				OnPropertyChanged();
			}
		}
		public string RequestID
		{
			get => requestID;
			set
			{
				if (requestID == value)
					return;
				requestID = value;
				OnPropertyChanged();
			}
		}
		public string FrontID
		{
			get => frontID;
			set
			{
				if (frontID == value)
					return;
				frontID = value;
				OnPropertyChanged();
			}
		}
		public int SessionID
		{
			get => sessionID;
			set
			{
				if (sessionID == value)
					return;
				sessionID = value;
				OnPropertyChanged();
			}
		}
		public string InsertDate
		{
			get => insertDate;
			set
			{
				if (insertDate == value)
					return;
				insertDate = value;
				OnPropertyChanged();
			}
		}
		public string InsertTime
		{
			get => insertTime;
			set
			{
				if (insertTime == value)
					return;
				insertTime = value;
				OnPropertyChanged();
			}
		}
		public string ExchangeInsertDate
		{
			get => exchangeInsertDate;
			set
			{
				if (exchangeInsertDate == value)
					return;
				exchangeInsertDate = value;
				OnPropertyChanged();
			}
		}
		public string ExchangeInsertTime
		{
			get => exchangeInsertTime;
			set
			{
				if (exchangeInsertTime == value)
					return;
				exchangeInsertTime = value;
				OnPropertyChanged();
			}
		}
		public string CancelDate
		{
			get => cancelDate;
			set
			{
				if (cancelDate == value)
					return;
				cancelDate = value;
				OnPropertyChanged();
			}
		}
		public string CancelTime
		{
			get => cancelTime;
			set
			{
				if (cancelTime == value)
					return;
				cancelTime = value;
				OnPropertyChanged();
			}
		}
		public ForceCloseReason ForceCloseReason
		{
			get => forceCloseReason;
			set
			{
				if (forceCloseReason == value)
					return;
				forceCloseReason = value;
				OnPropertyChanged();
			}
		}
		public IsLocalOrder IsLocalOrder
		{
			get => isLocalOrder;
			set
			{
				if (isLocalOrder == value)
					return;
				isLocalOrder = value;
				OnPropertyChanged();
			}
		}
		public string UserProductInfo
		{
			get => userProductInfo;
			set
			{
				if (userProductInfo == value)
					return;
				userProductInfo = value;
				OnPropertyChanged();
			}
		}
		public TimeCondition TimeCondition
		{
			get => timeCondition;
			set
			{
				if (timeCondition == value)
					return;
				timeCondition = value;
				OnPropertyChanged();
			}
		}
		public string GTDDate
		{
			get => gTDDate;
			set
			{
				if (gTDDate == value)
					return;
				gTDDate = value;
				OnPropertyChanged();
			}
		}
		public VolumeCondition VolumeCondition
		{
			get => volumeCondition;
			set
			{
				if (volumeCondition == value)
					return;
				volumeCondition = value;
				OnPropertyChanged();
			}
		}
		public int MinVolume
		{
			get => minVolume;
			set
			{
				if (minVolume == value)
					return;
				minVolume = value;
				OnPropertyChanged();
			}
		}
		public ContingentCondition ContingentCondition
		{
			get => contingentCondition;
			set
			{
				if (contingentCondition == value)
					return;
				contingentCondition = value;
				OnPropertyChanged();
			}
		}
		public double StopPrice
		{
			get => stopPrice;
			set
			{
				if (stopPrice == value)
					return;
				stopPrice = value;
				OnPropertyChanged();
			}
		}
		public int IsSwapOrder
		{
			get => isSwapOrder;
			set
			{
				if (isSwapOrder == value)
					return;
				isSwapOrder = value;
				OnPropertyChanged();
			}
		}
	}
	public class OrderCancel : PropertyChangedNotify
	{
		private string tradingDay = string.Empty;
		private string accountID = string.Empty;
		private string exchangeID = string.Empty;
		private string instrumentID = string.Empty;
		private string orderLocalID = string.Empty;
		private string origOrderLocalID = string.Empty;
		private string orderSysID = string.Empty;
		private Direction direction;
		private string orderRef = string.Empty;
		private string frontID = string.Empty;
		private int sessionID;
		private int errorID;
		private string errorMsg = string.Empty;
		private string insertDate = string.Empty;
		private string cancelDate = string.Empty;

		public string TradingDay
		{
			get => tradingDay;
			set
			{
				if (tradingDay == value)
					return;
				tradingDay = value;
				OnPropertyChanged();
			}
		}
		public string AccountID
		{
			get => accountID;
			set
			{
				if (accountID == value)
					return;
				accountID = value;
				OnPropertyChanged();
			}
		}
		public string ExchangeID
		{
			get => exchangeID;
			set
			{
				if (exchangeID == value)
					return;
				exchangeID = value;
				OnPropertyChanged();
			}
		}
		public string InstrumentID
		{
			get => instrumentID;
			set
			{
				if (instrumentID == value)
					return;
				instrumentID = value;
				OnPropertyChanged();
			}
		}
		public string OrderLocalID
		{
			get => orderLocalID;
			set
			{
				if (orderLocalID == value)
					return;
				orderLocalID = value;
				OnPropertyChanged();
			}
		}
		public string OrigOrderLocalID
		{
			get => origOrderLocalID;
			set
			{
				if (origOrderLocalID == value)
					return;
				origOrderLocalID = value;
				OnPropertyChanged();
			}
		}
		public string OrderSysID
		{
			get => orderSysID;
			set
			{
				if (orderSysID == value)
					return;
				orderSysID = value;
				OnPropertyChanged();
			}
		}
		public Direction Direction
		{
			get => direction;
			set
			{
				if (direction == value)
					return;
				direction = value;
				OnPropertyChanged();
			}
		}
		public string OrderRef
		{
			get => orderRef;
			set
			{
				if (orderRef == value)
					return;
				orderRef = value;
				OnPropertyChanged();
			}
		}
		public string FrontID
		{
			get => frontID;
			set
			{
				if (frontID == value)
					return;
				frontID = value;
				OnPropertyChanged();
			}
		}
		public int SessionID
		{
			get => sessionID;
			set
			{
				if (sessionID == value)
					return;
				sessionID = value;
				OnPropertyChanged();
			}
		}
		public int ErrorID
		{
			get => errorID;
			set
			{
				if (errorID == value)
					return;
				errorID = value;
				OnPropertyChanged();
			}
		}
		public string ErrorMsg
		{
			get => errorMsg;
			set
			{
				if (errorMsg == value)
					return;
				errorMsg = value;
				OnPropertyChanged();
			}
		}
		public string InsertDate
		{
			get => insertDate;
			set
			{
				if (insertDate == value)
					return;
				insertDate = value;
				OnPropertyChanged();
			}
		}
		public string CancelDate
		{
			get => cancelDate;
			set
			{
				if (cancelDate == value)
					return;
				cancelDate = value;
				OnPropertyChanged();
			}
		}
	}
	public class Trade : PropertyChangedNotify
	{
		private string tradingDay = string.Empty;
		private string accountID = string.Empty;
		private string exchangeID = string.Empty;
		private string instrumentID = string.Empty;
		private string tradeID = string.Empty;
		private Direction direction;
		private OffsetFlag offsetFlag;
		private HedgeFlag hedgeFlag;
		private double price;
		private int volume;
		private string orderLocalID = string.Empty;
		private string orderSysID = string.Empty;
		private string tradeTime = string.Empty;
		private string tradeDate = string.Empty;

		public string TradingDay
		{
			get => tradingDay;
			set
			{
				if (tradingDay == value)
					return;
				tradingDay = value;
				OnPropertyChanged();
			}
		}
		public string AccountID
		{
			get => accountID;
			set
			{
				if (accountID == value)
					return;
				accountID = value;
				OnPropertyChanged();
			}
		}
		public string ExchangeID
		{
			get => exchangeID;
			set
			{
				if (exchangeID == value)
					return;
				exchangeID = value;
				OnPropertyChanged();
			}
		}
		public string InstrumentID
		{
			get => instrumentID;
			set
			{
				if (instrumentID == value)
					return;
				instrumentID = value;
				OnPropertyChanged();
			}
		}
		public string TradeID
		{
			get => tradeID;
			set
			{
				if (tradeID == value)
					return;
				tradeID = value;
				OnPropertyChanged();
			}
		}
		public Direction Direction
		{
			get => direction;
			set
			{
				if (direction == value)
					return;
				direction = value;
				OnPropertyChanged();
			}
		}
		public OffsetFlag OffsetFlag
		{
			get => offsetFlag;
			set
			{
				if (offsetFlag == value)
					return;
				offsetFlag = value;
				OnPropertyChanged();
			}
		}
		public HedgeFlag HedgeFlag
		{
			get => hedgeFlag;
			set
			{
				if (hedgeFlag == value)
					return;
				hedgeFlag = value;
				OnPropertyChanged();
			}
		}
		public double Price
		{
			get => price;
			set
			{
				if (price == value)
					return;
				price = value;
				OnPropertyChanged();
			}
		}
		public int Volume
		{
			get => volume;
			set
			{
				if (volume == value)
					return;
				volume = value;
				OnPropertyChanged();
			}
		}
		public string OrderLocalID
		{
			get => orderLocalID;
			set
			{
				if (orderLocalID == value)
					return;
				orderLocalID = value;
				OnPropertyChanged();
			}
		}
		public string OrderSysID
		{
			get => orderSysID;
			set
			{
				if (orderSysID == value)
					return;
				orderSysID = value;
				OnPropertyChanged();
			}
		}
		public string TradeTime
		{
			get => tradeTime;
			set
			{
				if (tradeTime == value)
					return;
				tradeTime = value;
				OnPropertyChanged();
			}
		}
		public string TradeDate
		{
			get => tradeDate;
			set
			{
				if (tradeDate == value)
					return;
				tradeDate = value;
				OnPropertyChanged();
			}
		}
	}
}
