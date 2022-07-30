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
		private string requestID = string.Empty;
		/// <summary>
		/// 
		/// </summary>
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
}
