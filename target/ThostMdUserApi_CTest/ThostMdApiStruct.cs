using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MdApi
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CThostFtdcRspInfoField
    {
        public int ErrorID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string ErrorMsg;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CThostFtdcRspUserLoginField
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string LoginTime;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string SystemName;

        public int FrontID;

        public int SessionID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public string MaxOrderRef;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string SHFETime;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string DCETime;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string CZCETime;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string FFEXTime;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CThostFtdcUserLogoutField
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CThostFtdcSpecificInstrumentField
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CThostFtdcInstrumentField
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string InstrumentName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ProductID;

        public char ProductClass;

        public int DeliveryYear;

        public int DeliveryMonth;

        public int MaxMarketOrderVolume;

        public int MinMarketOrderVolume;

        public int MaxLimitOrderVolume;

        public int MinLimitOrderVolume;

        public int VolumeMultiple;

        public double PriceTick;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string CreateDate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string OpenDate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExpireDate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string StartDelivDate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string EndDelivDate;

        public char InstLifePhase;

        public int IsTrading;

        public char PositionType;

        public char PositionDateType;

        public double LongMarginRatio;

        public double ShortMarginRatio;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CThostFtdcDepthMarketDataField
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;

        public double LastPrice;

        public double PreSettlementPrice;

        public double PreClosePrice;

        public double PreOpenInterest;

        public double OpenPrice;

        public double HighestPrice;

        public double LowestPrice;

        public double Volume;

        public double Turnover;

        public double OpenInterest;

        public double ClosePrice;

        public double SettlementPrice;

        public double UpperLimitPrice;

        public double LowerLimitPrice;

        public double PreDelta;

        public double CurrDelta;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string UpdateTime;

        public int UpdateMillisec;

        public double BidPrice1;

        public int BidVolume1;

        public double AskPrice1;

        public int AskVolume1;

        public double BidPrice2;

        public int BidVolume2;

        public double AskPrice2;

        public int AskVolume2;

        public double BidPrice3;

        public int BidVolume3;

        public double AskPrice3;

        public int AskVolume3;

        public double BidPrice4;

        public int BidVolume4;

        public double AskPrice4;

        public int AskVolume4;

        public double BidPrice5;

        public int BidVolume5;

        public double AskPrice5;

        public int AskVolume5;

        public double AveragePrice;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ActionDay;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CThostFtdcExchangeStatusField
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradeDate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeDate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeTime;

        public char MarketStatus;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CThostFtdcOptionsInfoField
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string UnderlyingInstID;

        public char OptionsClass;

        public char OptionsMode;

        public double StrikePrice;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExpiredDate;

        public int StrikeUnit;

        public char OptionsDirect;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CThostFtdcFensUserInfoField
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        
        public char LoginMode;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct CThostFtdcReqUserLoginField
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string TradingDay;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string BrokerID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Password;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string UserProductInfo;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string InterfaceProductInfo;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ProtocolInfo;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string MacAddress;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string OneTimePassword;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string ClientIPAddress;
    }
    
    [StructLayout(LayoutKind.Sequential)] 
    public struct CThostFtdcQryInstrumentField
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string InstrumentID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
        public string ExchangeID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ExchangeInstID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        public string ProductID;
    }
}
