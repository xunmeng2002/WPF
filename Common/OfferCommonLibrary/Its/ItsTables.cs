using System;

namespace OfferCommonLibrary.Its
{
	public class ItsInsertOrder
	{
		public ItsInsertOrder()
		{}
		public ItsInsertOrder(string[] items)
		{
			SequenceNo = items[2];
			Reserve1 = items[3];
			Reserve2 = items[4];
			Reserve3 = items[5];
			Reserve4 = items[6];
			Reserve5 = items[7];
			Reserve6 = items[8];
			ExchangeID = items[9];
			InstrumentID = items[10];
			Price = items[11];
			Direction = items[12];
			Reserve7 = items[13];
			CombHedgeFlag = items[14];
			Volume = items[15];
			OrderPriceType = items[16];
			RequestID = items[17];
			Reserve8 = items[18];
			TimeCondition = items[19];
			GTDDate = items[20];
			VolumeCondition = items[21];
			MinVolume = items[22];
			IsSwapOrder = items[23];
			ForceCloseReason = items[24];
			AccountID = items[25];
			TradingDay = items[26];
		}

		public static readonly string ProtocolType = "R";
		public static readonly string Command = "216";
		private string sequenceNo = string.Empty;
		private string reserve1 = string.Empty;
		private string reserve2 = string.Empty;
		private string reserve3 = string.Empty;
		private string reserve4 = string.Empty;
		private string reserve5 = string.Empty;
		private string reserve6 = string.Empty;
		private string exchangeID = string.Empty;
		private string instrumentID = string.Empty;
		private string price = string.Empty;
		private string direction = string.Empty;
		private string reserve7 = string.Empty;
		private string combHedgeFlag = string.Empty;
		private string volume = string.Empty;
		private string orderPriceType = string.Empty;
		private string requestID = string.Empty;
		private string reserve8 = string.Empty;
		private string timeCondition = string.Empty;
		private string gTDDate = string.Empty;
		private string volumeCondition = string.Empty;
		private string minVolume = string.Empty;
		private string isSwapOrder = string.Empty;
		private string forceCloseReason = string.Empty;
		private string accountID = string.Empty;
		private string tradingDay = string.Empty;

		public string SequenceNo
		{ 
			get => sequenceNo;
			set => sequenceNo = value;
		}
		public string Reserve1
		{ 
			get => reserve1;
			set => reserve1 = value;
		}
		public string Reserve2
		{ 
			get => reserve2;
			set => reserve2 = value;
		}
		public string Reserve3
		{ 
			get => reserve3;
			set => reserve3 = value;
		}
		public string Reserve4
		{ 
			get => reserve4;
			set => reserve4 = value;
		}
		public string Reserve5
		{ 
			get => reserve5;
			set => reserve5 = value;
		}
		public string Reserve6
		{ 
			get => reserve6;
			set => reserve6 = value;
		}
		public string ExchangeID
		{ 
			get => exchangeID;
			set => exchangeID = value;
		}
		public string InstrumentID
		{ 
			get => instrumentID;
			set => instrumentID = value;
		}
		public string Price
		{ 
			get => price;
			set => price = value;
		}
		public string Direction
		{ 
			get => direction;
			set => direction = value;
		}
		public string Reserve7
		{ 
			get => reserve7;
			set => reserve7 = value;
		}
		public string CombHedgeFlag
		{ 
			get => combHedgeFlag;
			set => combHedgeFlag = value;
		}
		public string Volume
		{ 
			get => volume;
			set => volume = value;
		}
		public string OrderPriceType
		{ 
			get => orderPriceType;
			set => orderPriceType = value;
		}
		public string RequestID
		{ 
			get => requestID;
			set => requestID = value;
		}
		public string Reserve8
		{ 
			get => reserve8;
			set => reserve8 = value;
		}
		public string TimeCondition
		{ 
			get => timeCondition;
			set => timeCondition = value;
		}
		public string GTDDate
		{ 
			get => gTDDate;
			set => gTDDate = value;
		}
		public string VolumeCondition
		{ 
			get => volumeCondition;
			set => volumeCondition = value;
		}
		public string MinVolume
		{ 
			get => minVolume;
			set => minVolume = value;
		}
		public string IsSwapOrder
		{ 
			get => isSwapOrder;
			set => isSwapOrder = value;
		}
		public string ForceCloseReason
		{ 
			get => forceCloseReason;
			set => forceCloseReason = value;
		}
		public string AccountID
		{ 
			get => accountID;
			set => accountID = value;
		}
		public string TradingDay
		{ 
			get => tradingDay;
			set => tradingDay = value;
		}
		
		public override string ToString()
		{
			return ProtocolType + "|" + Command + "|" + SequenceNo + "|" + Reserve1 + "|" + Reserve2 + "|" + Reserve3 + "|" + Reserve4 + "|" + Reserve5 + "|" + Reserve6 + "|" + ExchangeID + "|" + InstrumentID + "|" + Price + "|" + Direction + "|" + Reserve7 + "|" + CombHedgeFlag + "|" + Volume + "|" + OrderPriceType + "|" + RequestID + "|" + Reserve8 + "|" + TimeCondition + "|" + GTDDate + "|" + VolumeCondition + "|" + MinVolume + "|" + IsSwapOrder + "|" + ForceCloseReason + "|" + AccountID + "|" + TradingDay;
		}
	}
	public class ItsInsertOrderCancel
	{
		public ItsInsertOrderCancel()
		{}
		public ItsInsertOrderCancel(string[] items)
		{
			SequenceNo = items[2];
			Reserve1 = items[3];
			Reserve2 = items[4];
			Reserve3 = items[5];
			Reserve4 = items[6];
			Reserve5 = items[7];
			Reserve6 = items[8];
			OrderRef = items[9];
			FrontID = items[10];
			SessionID = items[11];
			ExchangeID = items[12];
			OrderSysID = items[13];
			BrokerOrderID = items[14];
			ProcessorOrderID = items[15];
			InstrumentID = items[16];
			Direction = items[17];
			TradingDay = items[18];
		}

		public static readonly string ProtocolType = "R";
		public static readonly string Command = "217";
		private string sequenceNo = string.Empty;
		private string reserve1 = string.Empty;
		private string reserve2 = string.Empty;
		private string reserve3 = string.Empty;
		private string reserve4 = string.Empty;
		private string reserve5 = string.Empty;
		private string reserve6 = string.Empty;
		private string orderRef = string.Empty;
		private string frontID = string.Empty;
		private string sessionID = string.Empty;
		private string exchangeID = string.Empty;
		private string orderSysID = string.Empty;
		private string brokerOrderID = string.Empty;
		private string processorOrderID = string.Empty;
		private string instrumentID = string.Empty;
		private string direction = string.Empty;
		private string tradingDay = string.Empty;

		public string SequenceNo
		{ 
			get => sequenceNo;
			set => sequenceNo = value;
		}
		public string Reserve1
		{ 
			get => reserve1;
			set => reserve1 = value;
		}
		public string Reserve2
		{ 
			get => reserve2;
			set => reserve2 = value;
		}
		public string Reserve3
		{ 
			get => reserve3;
			set => reserve3 = value;
		}
		public string Reserve4
		{ 
			get => reserve4;
			set => reserve4 = value;
		}
		public string Reserve5
		{ 
			get => reserve5;
			set => reserve5 = value;
		}
		public string Reserve6
		{ 
			get => reserve6;
			set => reserve6 = value;
		}
		public string OrderRef
		{ 
			get => orderRef;
			set => orderRef = value;
		}
		public string FrontID
		{ 
			get => frontID;
			set => frontID = value;
		}
		public string SessionID
		{ 
			get => sessionID;
			set => sessionID = value;
		}
		public string ExchangeID
		{ 
			get => exchangeID;
			set => exchangeID = value;
		}
		public string OrderSysID
		{ 
			get => orderSysID;
			set => orderSysID = value;
		}
		public string BrokerOrderID
		{ 
			get => brokerOrderID;
			set => brokerOrderID = value;
		}
		public string ProcessorOrderID
		{ 
			get => processorOrderID;
			set => processorOrderID = value;
		}
		public string InstrumentID
		{ 
			get => instrumentID;
			set => instrumentID = value;
		}
		public string Direction
		{ 
			get => direction;
			set => direction = value;
		}
		public string TradingDay
		{ 
			get => tradingDay;
			set => tradingDay = value;
		}
		
		public override string ToString()
		{
			return ProtocolType + "|" + Command + "|" + SequenceNo + "|" + Reserve1 + "|" + Reserve2 + "|" + Reserve3 + "|" + Reserve4 + "|" + Reserve5 + "|" + Reserve6 + "|" + OrderRef + "|" + FrontID + "|" + SessionID + "|" + ExchangeID + "|" + OrderSysID + "|" + BrokerOrderID + "|" + ProcessorOrderID + "|" + InstrumentID + "|" + Direction + "|" + TradingDay;
		}
	}
	public class ItsRspOrder
	{
		public ItsRspOrder()
		{}
		public ItsRspOrder(string[] items)
		{
			SequenceNo = items[1];
			Reserve1 = items[2];
			Reserve2 = items[3];
			ErrorID = items[4];
			ErrorMsg = items[5];
			TradingDay = items[6];
		}

		public static readonly string ProtocolType = "A";
		private string sequenceNo = string.Empty;
		private string reserve1 = string.Empty;
		private string reserve2 = string.Empty;
		private string errorID = string.Empty;
		private string errorMsg = string.Empty;
		private string tradingDay = string.Empty;

		public string SequenceNo
		{ 
			get => sequenceNo;
			set => sequenceNo = value;
		}
		public string Reserve1
		{ 
			get => reserve1;
			set => reserve1 = value;
		}
		public string Reserve2
		{ 
			get => reserve2;
			set => reserve2 = value;
		}
		public string ErrorID
		{ 
			get => errorID;
			set => errorID = value;
		}
		public string ErrorMsg
		{ 
			get => errorMsg;
			set => errorMsg = value;
		}
		public string TradingDay
		{ 
			get => tradingDay;
			set => tradingDay = value;
		}
		
		public override string ToString()
		{
			return ProtocolType + "|" + SequenceNo + "|" + Reserve1 + "|" + Reserve2 + "|" + ErrorID + "|" + ErrorMsg + "|" + TradingDay;
		}
	}
	public class ItsOrder
	{
		public ItsOrder()
		{}
		public ItsOrder(string[] items)
		{
			Reserve1 = items[2];
			Reserve2 = items[3];
			Reserve3 = items[4];
			Reserve4 = items[5];
			ChannelID = items[6];
			ExchangeID = items[7];
			InstrumentID = items[8];
			OrderRef = items[9];
			InsertTime = items[10];
			CancelTime = items[11];
			OrderSysID = items[12];
			StatusMsg = items[13];
			Direction = items[14];
			CombOffsetFlag = items[15];
			CombHedgeFlag = items[16];
			OrderPriceType = items[17];
			OrderStatus = items[18];
			ForceCloseReason = items[19];
			RequestID = items[20];
			FrontID = items[21];
			SessionID = items[22];
			BrokerOrderID = items[23];
			VolumeTotalOriginal = items[24];
			VolumeTraded = items[25];
			InsertDate = items[26];
			TradingDay = items[27];
			LimitPrice = items[28];
			IsLocalOrder = items[29];
			UserProductInfo = items[30];
			TimeCondition = items[31];
			GTDDate = items[32];
			VolumeCondition = items[33];
			MinVolume = items[34];
			ContingentCondition = items[35];
			StopPrice = items[36];
			IsSwapOrder = items[37];
			Reserve5 = items[38];
		}

		public static readonly string ProtocolType = "B";
		public static readonly string Command = "52";
		private string reserve1 = string.Empty;
		private string reserve2 = string.Empty;
		private string reserve3 = string.Empty;
		private string reserve4 = string.Empty;
		private string channelID = string.Empty;
		private string exchangeID = string.Empty;
		private string instrumentID = string.Empty;
		private string orderRef = string.Empty;
		private string insertTime = string.Empty;
		private string cancelTime = string.Empty;
		private string orderSysID = string.Empty;
		private string statusMsg = string.Empty;
		private string direction = string.Empty;
		private string combOffsetFlag = string.Empty;
		private string combHedgeFlag = string.Empty;
		private string orderPriceType = string.Empty;
		private string orderStatus = string.Empty;
		private string forceCloseReason = string.Empty;
		private string requestID = string.Empty;
		private string frontID = string.Empty;
		private string sessionID = string.Empty;
		private string brokerOrderID = string.Empty;
		private string volumeTotalOriginal = string.Empty;
		private string volumeTraded = string.Empty;
		private string insertDate = string.Empty;
		private string tradingDay = string.Empty;
		private string limitPrice = string.Empty;
		private string isLocalOrder = string.Empty;
		private string userProductInfo = string.Empty;
		private string timeCondition = string.Empty;
		private string gTDDate = string.Empty;
		private string volumeCondition = string.Empty;
		private string minVolume = string.Empty;
		private string contingentCondition = string.Empty;
		private string stopPrice = string.Empty;
		private string isSwapOrder = string.Empty;
		private string reserve5 = string.Empty;

		public string Reserve1
		{ 
			get => reserve1;
			set => reserve1 = value;
		}
		public string Reserve2
		{ 
			get => reserve2;
			set => reserve2 = value;
		}
		public string Reserve3
		{ 
			get => reserve3;
			set => reserve3 = value;
		}
		public string Reserve4
		{ 
			get => reserve4;
			set => reserve4 = value;
		}
		public string ChannelID
		{ 
			get => channelID;
			set => channelID = value;
		}
		public string ExchangeID
		{ 
			get => exchangeID;
			set => exchangeID = value;
		}
		public string InstrumentID
		{ 
			get => instrumentID;
			set => instrumentID = value;
		}
		public string OrderRef
		{ 
			get => orderRef;
			set => orderRef = value;
		}
		public string InsertTime
		{ 
			get => insertTime;
			set => insertTime = value;
		}
		public string CancelTime
		{ 
			get => cancelTime;
			set => cancelTime = value;
		}
		public string OrderSysID
		{ 
			get => orderSysID;
			set => orderSysID = value;
		}
		public string StatusMsg
		{ 
			get => statusMsg;
			set => statusMsg = value;
		}
		public string Direction
		{ 
			get => direction;
			set => direction = value;
		}
		public string CombOffsetFlag
		{ 
			get => combOffsetFlag;
			set => combOffsetFlag = value;
		}
		public string CombHedgeFlag
		{ 
			get => combHedgeFlag;
			set => combHedgeFlag = value;
		}
		public string OrderPriceType
		{ 
			get => orderPriceType;
			set => orderPriceType = value;
		}
		public string OrderStatus
		{ 
			get => orderStatus;
			set => orderStatus = value;
		}
		public string ForceCloseReason
		{ 
			get => forceCloseReason;
			set => forceCloseReason = value;
		}
		public string RequestID
		{ 
			get => requestID;
			set => requestID = value;
		}
		public string FrontID
		{ 
			get => frontID;
			set => frontID = value;
		}
		public string SessionID
		{ 
			get => sessionID;
			set => sessionID = value;
		}
		public string BrokerOrderID
		{ 
			get => brokerOrderID;
			set => brokerOrderID = value;
		}
		public string VolumeTotalOriginal
		{ 
			get => volumeTotalOriginal;
			set => volumeTotalOriginal = value;
		}
		public string VolumeTraded
		{ 
			get => volumeTraded;
			set => volumeTraded = value;
		}
		public string InsertDate
		{ 
			get => insertDate;
			set => insertDate = value;
		}
		public string TradingDay
		{ 
			get => tradingDay;
			set => tradingDay = value;
		}
		public string LimitPrice
		{ 
			get => limitPrice;
			set => limitPrice = value;
		}
		public string IsLocalOrder
		{ 
			get => isLocalOrder;
			set => isLocalOrder = value;
		}
		public string UserProductInfo
		{ 
			get => userProductInfo;
			set => userProductInfo = value;
		}
		public string TimeCondition
		{ 
			get => timeCondition;
			set => timeCondition = value;
		}
		public string GTDDate
		{ 
			get => gTDDate;
			set => gTDDate = value;
		}
		public string VolumeCondition
		{ 
			get => volumeCondition;
			set => volumeCondition = value;
		}
		public string MinVolume
		{ 
			get => minVolume;
			set => minVolume = value;
		}
		public string ContingentCondition
		{ 
			get => contingentCondition;
			set => contingentCondition = value;
		}
		public string StopPrice
		{ 
			get => stopPrice;
			set => stopPrice = value;
		}
		public string IsSwapOrder
		{ 
			get => isSwapOrder;
			set => isSwapOrder = value;
		}
		public string Reserve5
		{ 
			get => reserve5;
			set => reserve5 = value;
		}
		
		public override string ToString()
		{
			return ProtocolType + "|" + Command + "|" + Reserve1 + "|" + Reserve2 + "|" + Reserve3 + "|" + Reserve4 + "|" + ChannelID + "|" + ExchangeID + "|" + InstrumentID + "|" + OrderRef + "|" + InsertTime + "|" + CancelTime + "|" + OrderSysID + "|" + StatusMsg + "|" + Direction + "|" + CombOffsetFlag + "|" + CombHedgeFlag + "|" + OrderPriceType + "|" + OrderStatus + "|" + ForceCloseReason + "|" + RequestID + "|" + FrontID + "|" + SessionID + "|" + BrokerOrderID + "|" + VolumeTotalOriginal + "|" + VolumeTraded + "|" + InsertDate + "|" + TradingDay + "|" + LimitPrice + "|" + IsLocalOrder + "|" + UserProductInfo + "|" + TimeCondition + "|" + GTDDate + "|" + VolumeCondition + "|" + MinVolume + "|" + ContingentCondition + "|" + StopPrice + "|" + IsSwapOrder + "|" + Reserve5;
		}
	}
	public class ItsTrade
	{
		public ItsTrade()
		{}
		public ItsTrade(string[] items)
		{
			Reserve1 = items[2];
			Reserve2 = items[3];
			Reserve3 = items[4];
			Reserve4 = items[5];
			ChannelID = items[6];
			ExchangeID = items[7];
			InstrumentID = items[8];
			OrderRef = items[9];
			OrderSysID = items[10];
			TradeTime = items[11];
			TradeID = items[12];
			Direction = items[13];
			OffsetFlag = items[14];
			HedgeFlag = items[15];
			BrokerOrderID = items[16];
			Volume = items[17];
			TradeDate = items[18];
			TradingDay = items[19];
			Price = items[20];
			Reserve5 = items[21];
			TradeType = items[22];
			ExchangeTradeID = items[23];
			Reserve7 = items[24];
			Reserve8 = items[25];
		}

		public static readonly string ProtocolType = "B";
		public static readonly string Command = "53";
		private string reserve1 = string.Empty;
		private string reserve2 = string.Empty;
		private string reserve3 = string.Empty;
		private string reserve4 = string.Empty;
		private string channelID = string.Empty;
		private string exchangeID = string.Empty;
		private string instrumentID = string.Empty;
		private string orderRef = string.Empty;
		private string orderSysID = string.Empty;
		private string tradeTime = string.Empty;
		private string tradeID = string.Empty;
		private string direction = string.Empty;
		private string offsetFlag = string.Empty;
		private string hedgeFlag = string.Empty;
		private string brokerOrderID = string.Empty;
		private string volume = string.Empty;
		private string tradeDate = string.Empty;
		private string tradingDay = string.Empty;
		private string price = string.Empty;
		private string reserve5 = string.Empty;
		private string tradeType = string.Empty;
		private string exchangeTradeID = string.Empty;
		private string reserve7 = string.Empty;
		private string reserve8 = string.Empty;

		public string Reserve1
		{ 
			get => reserve1;
			set => reserve1 = value;
		}
		public string Reserve2
		{ 
			get => reserve2;
			set => reserve2 = value;
		}
		public string Reserve3
		{ 
			get => reserve3;
			set => reserve3 = value;
		}
		public string Reserve4
		{ 
			get => reserve4;
			set => reserve4 = value;
		}
		public string ChannelID
		{ 
			get => channelID;
			set => channelID = value;
		}
		public string ExchangeID
		{ 
			get => exchangeID;
			set => exchangeID = value;
		}
		public string InstrumentID
		{ 
			get => instrumentID;
			set => instrumentID = value;
		}
		public string OrderRef
		{ 
			get => orderRef;
			set => orderRef = value;
		}
		public string OrderSysID
		{ 
			get => orderSysID;
			set => orderSysID = value;
		}
		public string TradeTime
		{ 
			get => tradeTime;
			set => tradeTime = value;
		}
		public string TradeID
		{ 
			get => tradeID;
			set => tradeID = value;
		}
		public string Direction
		{ 
			get => direction;
			set => direction = value;
		}
		public string OffsetFlag
		{ 
			get => offsetFlag;
			set => offsetFlag = value;
		}
		public string HedgeFlag
		{ 
			get => hedgeFlag;
			set => hedgeFlag = value;
		}
		public string BrokerOrderID
		{ 
			get => brokerOrderID;
			set => brokerOrderID = value;
		}
		public string Volume
		{ 
			get => volume;
			set => volume = value;
		}
		public string TradeDate
		{ 
			get => tradeDate;
			set => tradeDate = value;
		}
		public string TradingDay
		{ 
			get => tradingDay;
			set => tradingDay = value;
		}
		public string Price
		{ 
			get => price;
			set => price = value;
		}
		public string Reserve5
		{ 
			get => reserve5;
			set => reserve5 = value;
		}
		public string TradeType
		{ 
			get => tradeType;
			set => tradeType = value;
		}
		public string ExchangeTradeID
		{ 
			get => exchangeTradeID;
			set => exchangeTradeID = value;
		}
		public string Reserve7
		{ 
			get => reserve7;
			set => reserve7 = value;
		}
		public string Reserve8
		{ 
			get => reserve8;
			set => reserve8 = value;
		}
		
		public override string ToString()
		{
			return ProtocolType + "|" + Command + "|" + Reserve1 + "|" + Reserve2 + "|" + Reserve3 + "|" + Reserve4 + "|" + ChannelID + "|" + ExchangeID + "|" + InstrumentID + "|" + OrderRef + "|" + OrderSysID + "|" + TradeTime + "|" + TradeID + "|" + Direction + "|" + OffsetFlag + "|" + HedgeFlag + "|" + BrokerOrderID + "|" + Volume + "|" + TradeDate + "|" + TradingDay + "|" + Price + "|" + Reserve5 + "|" + TradeType + "|" + ExchangeTradeID + "|" + Reserve7 + "|" + Reserve8;
		}
	}
	public class ItsRtnOrderCancel
	{
		public ItsRtnOrderCancel()
		{}
		public ItsRtnOrderCancel(string[] items)
		{
			Reserve1 = items[2];
			Reserve2 = items[3];
			Reserve3 = items[4];
			Reserve4 = items[5];
			ChannelID = items[6];
			BrokerOrderID = items[7];
			OrderRef = items[8];
			FrontID = items[9];
			SessionID = items[10];
			ExchangeID = items[11];
			OrderSysID = items[12];
			Reserve5 = items[13];
			ErrorID = items[14];
			ErrorMsg = items[15];
			TradingDay = items[16];
		}

		public static readonly string ProtocolType = "B";
		public static readonly string Command = "54";
		private string reserve1 = string.Empty;
		private string reserve2 = string.Empty;
		private string reserve3 = string.Empty;
		private string reserve4 = string.Empty;
		private string channelID = string.Empty;
		private string brokerOrderID = string.Empty;
		private string orderRef = string.Empty;
		private string frontID = string.Empty;
		private string sessionID = string.Empty;
		private string exchangeID = string.Empty;
		private string orderSysID = string.Empty;
		private string reserve5 = string.Empty;
		private string errorID = string.Empty;
		private string errorMsg = string.Empty;
		private string tradingDay = string.Empty;

		public string Reserve1
		{ 
			get => reserve1;
			set => reserve1 = value;
		}
		public string Reserve2
		{ 
			get => reserve2;
			set => reserve2 = value;
		}
		public string Reserve3
		{ 
			get => reserve3;
			set => reserve3 = value;
		}
		public string Reserve4
		{ 
			get => reserve4;
			set => reserve4 = value;
		}
		public string ChannelID
		{ 
			get => channelID;
			set => channelID = value;
		}
		public string BrokerOrderID
		{ 
			get => brokerOrderID;
			set => brokerOrderID = value;
		}
		public string OrderRef
		{ 
			get => orderRef;
			set => orderRef = value;
		}
		public string FrontID
		{ 
			get => frontID;
			set => frontID = value;
		}
		public string SessionID
		{ 
			get => sessionID;
			set => sessionID = value;
		}
		public string ExchangeID
		{ 
			get => exchangeID;
			set => exchangeID = value;
		}
		public string OrderSysID
		{ 
			get => orderSysID;
			set => orderSysID = value;
		}
		public string Reserve5
		{ 
			get => reserve5;
			set => reserve5 = value;
		}
		public string ErrorID
		{ 
			get => errorID;
			set => errorID = value;
		}
		public string ErrorMsg
		{ 
			get => errorMsg;
			set => errorMsg = value;
		}
		public string TradingDay
		{ 
			get => tradingDay;
			set => tradingDay = value;
		}
		
		public override string ToString()
		{
			return ProtocolType + "|" + Command + "|" + Reserve1 + "|" + Reserve2 + "|" + Reserve3 + "|" + Reserve4 + "|" + ChannelID + "|" + BrokerOrderID + "|" + OrderRef + "|" + FrontID + "|" + SessionID + "|" + ExchangeID + "|" + OrderSysID + "|" + Reserve5 + "|" + ErrorID + "|" + ErrorMsg + "|" + TradingDay;
		}
	}
}
