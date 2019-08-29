using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MdApi
{
    public struct CThostFtdcMdApi
    {
        const string DLL_NAME = "ThostMdUserApi_C.dll";

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern internal void CreateFtdcMdApi_C(string pszFlowPath = "", bool bIsUsingUdp = false, bool bIsMulticast = false, bool bIsLastQuot = true);

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern internal void Release();

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern internal int Init();

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern internal int Join();

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern internal string GetTradingDay();

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern internal void RegisterFront(string pszFrontAddress);

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern internal void RegisterNameServer(string pszNsAddress);

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern internal void RegisterFensUserInfo(ref CThostFtdcFensUserInfoField pFensUserInfo);

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern internal void RegisterSpi(IntPtr spi);

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern internal int SubscribeMarketData(string[] ppInstrumentID, int nCount);

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern internal int UnSubscribeMarketData(string[] ppInstrumentID, int nCount);

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern internal int ReqUserLogin(ref CThostFtdcReqUserLoginField pReqUserLoginField, int nRequestID);

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern internal int ReqUserLogout(ref CThostFtdcUserLogoutField pUserLogout, int nRequestID);

        [DllImport(DLL_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        static extern internal int ReqQryInstrument(ref CThostFtdcQryInstrumentField pQryInstrument, int nRequestID);
    }
}
