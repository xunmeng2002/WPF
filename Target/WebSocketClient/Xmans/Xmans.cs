using System;
using System.Collections.Generic;
using System.Text;

namespace WebSocketClient
{
	public class ReqLogin : PropertyChangedNotify
	{
		public string? username { get; set; }
		public string? password { get; set; }
	}
	public class ReqOrder : PropertyChangedNotify
	{
		public string? customerId { get; set; }
		public long? frontId { get; set; }
		public int? acctType { get; set; }
		public string? investid { get; set; }
		public int? market { get; set; }
		public string? securityId { get; set; }
		public int? bsType { get; set; }
		public int? isCancel { get; set; }
		public int? ordPrice { get; set; }
		public int? ordQty { get; set; }
		public int? ordType { get; set; }
	}


	public class RspLogin : PropertyChangedNotify
	{
		private string? Type;
		public string? type
		{
			get => Type;
			set
			{
				if (Type == value)
					return;
				Type = value;
				OnPropertyChanged();
			}
		}
		private int? Reqid;
		public int? reqid
		{
			get => Reqid;
			set
			{
				if (Reqid == value)
					return;
				Reqid = value;
				OnPropertyChanged();
			}
		}
		private int? Errno;
		public int? errno
		{
			get => Errno;
			set
			{
				if (Errno == value)
					return;
				Errno = value;
				OnPropertyChanged();
			}
		}
		private string? Errmsg;
		public string? errmsg
		{
			get => Errmsg;
			set
			{
				if (Errmsg == value)
					return;
				Errmsg = value;
				OnPropertyChanged();
			}
		}
		private string? Data;
		public string? data
		{
			get => Data;
			set
			{
				if (Data == value)
					return;
				Data = value;
				OnPropertyChanged();
			}
		}
		private int? TradeDay;
		public int? tradeDay
		{
			get => TradeDay;
			set
			{
				if (TradeDay == value)
					return;
				TradeDay = value;
				OnPropertyChanged();
			}
		}
		private int? Updatetime;
		public int? updatetime
		{
			get => Updatetime;
			set
			{
				if (Updatetime == value)
					return;
				Updatetime = value;
				OnPropertyChanged();
			}
		}
		private int? Sessionid;
		public int? sessionid
		{
			get => Sessionid;
			set
			{
				if (Sessionid == value)
					return;
				Sessionid = value;
				OnPropertyChanged();
			}
		}
	}
	public class Order : PropertyChangedNotify
	{
		private bool? IsSelected = false;
		public bool? isSelected
		{
			get => IsSelected;
			set
			{
				if (IsSelected == value)
					return;
				IsSelected = value;
				OnPropertyChanged();
			}
		}
		private string? Type;
		public string? type
		{
			get => Type;
			set
			{
				if (Type == value)
					return;
				Type = value;
				OnPropertyChanged();
			}
		}
		private int? Reqid;
		public int? reqid
		{
			get => Reqid;
			set
			{
				if (Reqid == value)
					return;
				Reqid = value;
				OnPropertyChanged();
			}
		}
		private int? Envno;
		public int? envno
		{
			get => Envno;
			set
			{
				if (Envno == value)
					return;
				Envno = value;
				OnPropertyChanged();
			}
		}
		private string? CustomerId;
		public string? customerId
		{
			get => CustomerId;
			set
			{
				if (CustomerId == value)
					return;
				CustomerId = value;
				OnPropertyChanged();
			}
		}
		private string? Investid;
		public string? investid
		{
			get => Investid;
			set
			{
				if (Investid == value)
					return;
				Investid = value;
				OnPropertyChanged();
			}
		}
		private int? Plotid;
		public int? plotid
		{
			get => Plotid;
			set
			{
				if (Plotid == value)
					return;
				Plotid = value;
				OnPropertyChanged();
			}
		}
		private int? LocalId;
		public int? localId
		{
			get => LocalId;
			set
			{
				if (LocalId == value)
					return;
				LocalId = value;
				OnPropertyChanged();
			}
		}
		private int? OrderStatus;
		public int? orderStatus
		{
			get => OrderStatus;
			set
			{
				if (OrderStatus == value)
					return;
				OrderStatus = value;
				OnPropertyChanged();
			}
		}
		private int? Market;
		public int? market
		{
			get => Market;
			set
			{
				if (Market == value)
					return;
				Market = value;
				OnPropertyChanged();
			}
		}
		private string? SecurityId;
		public string? securityId
		{
			get => SecurityId;
			set
			{
				if (SecurityId == value)
					return;
				SecurityId = value;
				OnPropertyChanged();
			}
		}
		private int? OrdQty;
		public int? ordQty
		{
			get => OrdQty;
			set
			{
				if (OrdQty == value)
					return;
				OrdQty = value;
				OnPropertyChanged();
			}
		}
		private int? OrdPrice;
		public int? ordPrice
		{
			get => OrdPrice;
			set
			{
				if (OrdPrice == value)
					return;
				OrdPrice = value;
				OnPropertyChanged();
			}
		}
		private int? TradeQty;
		public int? tradeQty
		{
			get => TradeQty;
			set
			{
				if (TradeQty == value)
					return;
				TradeQty = value;
				OnPropertyChanged();
			}
		}
		private int? TradeAvgPx;
		public int? tradeAvgPx
		{
			get => TradeAvgPx;
			set
			{
				if (TradeAvgPx == value)
					return;
				TradeAvgPx = value;
				OnPropertyChanged();
			}
		}
		private int? SendLocTime;
		public int? sendLocTime
		{
			get => SendLocTime;
			set
			{
				if (SendLocTime == value)
					return;
				SendLocTime = value;
				OnPropertyChanged();
			}
		}
		private int? CnfLocTime;
		public int? cnfLocTime
		{
			get => CnfLocTime;
			set
			{
				if (CnfLocTime == value)
					return;
				CnfLocTime = value;
				OnPropertyChanged();
			}
		}
		private int? SendTime;
		public int? sendTime
		{
			get => SendTime;
			set
			{
				if (SendTime == value)
					return;
				SendTime = value;
				OnPropertyChanged();
			}
		}
		private int? CnfTime;
		public int? cnfTime
		{
			get => CnfTime;
			set
			{
				if (CnfTime == value)
					return;
				CnfTime = value;
				OnPropertyChanged();
			}
		}
		private int? ErrorId;
		public int? errorId
		{
			get => ErrorId;
			set
			{
				if (ErrorId == value)
					return;
				ErrorId = value;
				OnPropertyChanged();
			}
		}
		private string? ErrorMsg;
		public string? errorMsg
		{
			get => ErrorMsg;
			set
			{
				if (ErrorMsg == value)
					return;
				ErrorMsg = value;
				OnPropertyChanged();
			}
		}
	}
}
