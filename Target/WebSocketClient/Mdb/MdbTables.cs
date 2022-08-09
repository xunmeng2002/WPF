using System;
using System.Collections.Generic;
using System.Text;

namespace WebSocketClient.Mdb
{
	public class Order : PropertyChangedNotify
	{
		private string accountID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
		private string exchangeID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
		private string instrumentID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
		private string orderSysID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
		private Direction direction;
		/// <summary>
		/// 
		/// </summary>
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
		private OrderPriceType orderPriceType;
		/// <summary>
		/// 
		/// </summary>
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
		private double price;
		/// <summary>
		/// 
		/// </summary>
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
		private int volume;
		/// <summary>
		/// 
		/// </summary>
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
		private int volumeTraded;
		/// <summary>
		/// 
		/// </summary>
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
		private OrderStatus orderStatus;
		/// <summary>
		/// 
		/// </summary>
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
		private long requestID;
		/// <summary>
		/// 
		/// </summary>
		public long RequestID
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
		private long sessionID;
		/// <summary>
		/// 
		/// </summary>
		public long SessionID
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
		private string insertDate = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
		private string insertTime = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
		private int errorID;
		/// <summary>
		/// 
		/// </summary>
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
		private string errorMsg = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
	}
	public class Trade : PropertyChangedNotify
	{
		private string accountID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
		private string exchangeID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
		private string instrumentID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
		private string tradeID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
		private Direction direction;
		/// <summary>
		/// 
		/// </summary>
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
		private double price;
		/// <summary>
		/// 
		/// </summary>
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
		private int volume;
		/// <summary>
		/// 
		/// </summary>
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
		private string orderLocalID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
		private string orderSysID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
		private string tradeTime = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
		private string tradeDate = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
	public class Position : PropertyChangedNotify
	{
		private string accountID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
		private string exchangeID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
		private string instrumentID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
		private Direction direction;
		/// <summary>
		/// 
		/// </summary>
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
		private double openPrice;
		/// <summary>
		/// 
		/// </summary>
		public double OpenPrice
		{
			get => openPrice;
			set
			{
				if (openPrice == value)
					return;
				openPrice = value;
				OnPropertyChanged();
			}
		}
		private double lastPrice;
		/// <summary>
		/// 
		/// </summary>
		public double LastPrice
		{
			get => lastPrice;
			set
			{
				if (lastPrice == value)
					return;
				lastPrice = value;
				OnPropertyChanged();
			}
		}
		private int volume;
		/// <summary>
		/// 
		/// </summary>
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
		private double profit;
		/// <summary>
		/// 
		/// </summary>
		public double Profit
		{
			get => profit;
			set
			{
				if (profit == value)
					return;
				profit = value;
				OnPropertyChanged();
			}
		}
	}
	public class BasketStrategy : PropertyChangedNotify
	{
		private string accountID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
		private string orderSysID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
		private int executeType;
		/// <summary>
		/// 
		/// </summary>
		public int ExecuteType
		{
			get => executeType;
			set
			{
				if (executeType == value)
					return;
				executeType = value;
				OnPropertyChanged();
			}
		}
		private int strategyType;
		/// <summary>
		/// 
		/// </summary>
		public int StrategyType
		{
			get => strategyType;
			set
			{
				if (strategyType == value)
					return;
				strategyType = value;
				OnPropertyChanged();
			}
		}
		private int ascendSpeed;
		/// <summary>
		/// 
		/// </summary>
		public int AscendSpeed
		{
			get => ascendSpeed;
			set
			{
				if (ascendSpeed == value)
					return;
				ascendSpeed = value;
				OnPropertyChanged();
			}
		}
		private int tradeRate;
		/// <summary>
		/// 
		/// </summary>
		public int TradeRate
		{
			get => tradeRate;
			set
			{
				if (tradeRate == value)
					return;
				tradeRate = value;
				OnPropertyChanged();
			}
		}
		private int cancelRate;
		/// <summary>
		/// 
		/// </summary>
		public int CancelRate
		{
			get => cancelRate;
			set
			{
				if (cancelRate == value)
					return;
				cancelRate = value;
				OnPropertyChanged();
			}
		}
		private int remainVolume;
		/// <summary>
		/// 
		/// </summary>
		public int RemainVolume
		{
			get => remainVolume;
			set
			{
				if (remainVolume == value)
					return;
				remainVolume = value;
				OnPropertyChanged();
			}
		}
		private string formula = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string Formula
		{
			get => formula;
			set
			{
				if (formula == value)
					return;
				formula = value;
				OnPropertyChanged();
			}
		}
		private long gapTime;
		/// <summary>
		/// 
		/// </summary>
		public long GapTime
		{
			get => gapTime;
			set
			{
				if (gapTime == value)
					return;
				gapTime = value;
				OnPropertyChanged();
			}
		}
		private int beginTime;
		/// <summary>
		/// 
		/// </summary>
		public int BeginTime
		{
			get => beginTime;
			set
			{
				if (beginTime == value)
					return;
				beginTime = value;
				OnPropertyChanged();
			}
		}
		private int endTime;
		/// <summary>
		/// 
		/// </summary>
		public int EndTime
		{
			get => endTime;
			set
			{
				if (endTime == value)
					return;
				endTime = value;
				OnPropertyChanged();
			}
		}
		private string basketFile = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string BasketFile
		{
			get => basketFile;
			set
			{
				if (basketFile == value)
					return;
				basketFile = value;
				OnPropertyChanged();
			}
		}
		private long requestID;
		/// <summary>
		/// 
		/// </summary>
		public long RequestID
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
		private long sessionID;
		/// <summary>
		/// 
		/// </summary>
		public long SessionID
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
	}
}
