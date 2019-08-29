using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MdApi
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FunOnFrontConnected();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FunOnFrontDisconnected(int nReason);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FunOnHeartBeatWarning(int nTimeLapse);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FunOnRspUserLogin(ref CThostFtdcRspUserLoginField pRspUserLogin, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FunOnRspUserLogout(ref CThostFtdcUserLogoutField pUserLogout, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FunOnRspError(ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FunOnRspSubMarketData(ref CThostFtdcSpecificInstrumentField pSpecificInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FunOnRspUnSubMarketData(ref CThostFtdcSpecificInstrumentField pSpecificInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FunOnRspQryInstrument(ref CThostFtdcInstrumentField pInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FunOnRtnDepthMarketData(ref CThostFtdcDepthMarketDataField pDepthMarketData);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FunOnRtnExchangeStatus(ref CThostFtdcExchangeStatusField pExchangeStatus);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FunOnRtnOptionsInfo(ref CThostFtdcOptionsInfoField pOptionsInfo);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void FunOnRtnTemplateMarketData(int nTemplateID, IntPtr pMarketData);

    public struct CThostFtdcMdSpi
    {
        public FunOnFrontConnected onFrontConnected;
        public FunOnFrontDisconnected onFrontDisconnected;
        public FunOnHeartBeatWarning onHeartBeatWarning;
        public FunOnRspUserLogin onRspUserLogin;
        public FunOnRspUserLogout onRspUserLogout;
        public FunOnRspError onRspError;
        public FunOnRspSubMarketData onRspSubMarketData;
        public FunOnRspUnSubMarketData onRspUnSubMarketData;
        public FunOnRspQryInstrument onRspQryInstrument;
        public FunOnRtnDepthMarketData onRtnDepthMarketData;
        public FunOnRtnExchangeStatus onRtnExchangeStatus;
        public FunOnRtnOptionsInfo onRtnOptionsInfo;
        public FunOnRtnTemplateMarketData onRtnTemplateMarketData;
    }

    public struct CThostFtdcMdSpiImpl
    {
        
        static int m_count = 0;

        static public void FrontConnected()
        {
            Console.WriteLine("OnFrontConnected");
        }
        static public void FrontDisconnected(int nReason)
        {
            Console.WriteLine("OnFrontDisconnected");
        }
        static public void HeartBeatWarning(int nTimeLapse)
        {
            Console.WriteLine("OnHeartBeatWarning");
        }
        static public void RspUserLogin(ref CThostFtdcRspUserLoginField pRspUserLogin, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
        {
            Console.WriteLine("OnRspUserLogin");
        }
        static public void RspUserLogout(ref CThostFtdcUserLogoutField pUserLogout, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
        {
            Console.WriteLine("OnRspUserLogout");
        }
        static public void RspError(ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
        {
            Console.WriteLine("OnRspError");
        }
        static public void RspSubMarketData(ref CThostFtdcSpecificInstrumentField pSpecificInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
        {
            Console.WriteLine("OnRspSubMarketData");
        }
        static public void RspUnSubMarketData(ref CThostFtdcSpecificInstrumentField pSpecificInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
        {
            Console.WriteLine("OnRspUnSubMarketData");
        }
        static public void RspQryInstrument(ref CThostFtdcInstrumentField pInstrument, ref CThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
        {
            Console.WriteLine("OnRspQryInstrument");
        }
        static public void RtnDepthMarketData(ref CThostFtdcDepthMarketDataField pDepthMarketData)
        {
            if(m_count % 10 == 0)
            {
                Console.WriteLine("ExchangeID, ExchangeInstID, InstrumentID, LastPrice, PreSettlementPrice, OpenPrice, HighestPrice, LowestPrice, Volume, ClosePrice, UpperLimitPrice, LowerLimitPrice, BidPrice1, AskPrice1, BidVolume1, AskVolume1");
                m_count = 0;
            }
            m_count++;
            Console.WriteLine("OnRtnDepthMarketData: [{0}], [{1}],[{2}],[{3}],[{4}],[{5}],[{6}],[{7}],[{8}],[{9}],[{10}],[{11}],[{12}],[{13}], [{14}], [{15}]",
                pDepthMarketData.ExchangeID, pDepthMarketData.ExchangeInstID, pDepthMarketData.InstrumentID, pDepthMarketData.LastPrice, pDepthMarketData.PreSettlementPrice, pDepthMarketData.OpenPrice, 
                pDepthMarketData.HighestPrice, pDepthMarketData.LowestPrice, pDepthMarketData.Volume, pDepthMarketData.ClosePrice, pDepthMarketData.UpperLimitPrice, pDepthMarketData.LowerLimitPrice,
                pDepthMarketData.BidPrice1, pDepthMarketData.AskPrice1, pDepthMarketData.BidVolume1, pDepthMarketData.AskVolume1);
        }
        static public void RtnExchangeStatus(ref CThostFtdcExchangeStatusField pExchangeStatus)
        {
            Console.WriteLine("OnRtnExchangeStatus");
        }
        static public void RtnOptionsInfo(ref CThostFtdcOptionsInfoField pOptionsInfo)
        {
            Console.WriteLine("OnRtnOptionsInfo");
        }
        static public void RtnTemplateMarketData(int nTemplateID, IntPtr pMarketData)
        {
            Console.WriteLine("OnRtnTemplateMarketData");
        }
    }
}
