using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MdApi;

namespace ThostMdUserApi_CTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            m_md_spi = new CThostFtdcMdSpi();
            m_md_spi.onFrontConnected = new FunOnFrontConnected(CThostFtdcMdSpiImpl.FrontConnected);
            m_md_spi.onFrontDisconnected = new FunOnFrontDisconnected(CThostFtdcMdSpiImpl.FrontDisconnected);
            m_md_spi.onHeartBeatWarning = new FunOnHeartBeatWarning(CThostFtdcMdSpiImpl.HeartBeatWarning);
            m_md_spi.onRspUserLogin = new FunOnRspUserLogin(CThostFtdcMdSpiImpl.RspUserLogin);
            m_md_spi.onRspUserLogout = new FunOnRspUserLogout(CThostFtdcMdSpiImpl.RspUserLogout);
            m_md_spi.onRspError = new FunOnRspError(CThostFtdcMdSpiImpl.RspError);
            m_md_spi.onRspSubMarketData = new FunOnRspSubMarketData(CThostFtdcMdSpiImpl.RspSubMarketData);
            m_md_spi.onRspUnSubMarketData = new FunOnRspUnSubMarketData(CThostFtdcMdSpiImpl.RspUnSubMarketData);
            m_md_spi.onRspQryInstrument = new FunOnRspQryInstrument(CThostFtdcMdSpiImpl.RspQryInstrument);
            m_md_spi.onRtnDepthMarketData = new FunOnRtnDepthMarketData(CThostFtdcMdSpiImpl.RtnDepthMarketData);
            m_md_spi.onRtnExchangeStatus = new FunOnRtnExchangeStatus(CThostFtdcMdSpiImpl.RtnExchangeStatus);
            m_md_spi.onRtnOptionsInfo = new FunOnRtnOptionsInfo(CThostFtdcMdSpiImpl.RtnOptionsInfo);
            m_md_spi.onRtnTemplateMarketData = new FunOnRtnTemplateMarketData(CThostFtdcMdSpiImpl.RtnTemplateMarketData);

            int size = Marshal.SizeOf(m_md_spi);
            m_md_spi_point = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(m_md_spi, m_md_spi_point, true);

            CThostFtdcMdApi.CreateFtdcMdApi_C();
            CThostFtdcMdApi.RegisterSpi(m_md_spi_point);
            CThostFtdcMdApi.RegisterFront("tcp://192.168.1.54:15999");
            CThostFtdcMdApi.Init();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CThostFtdcReqUserLoginField req_user_login = new CThostFtdcReqUserLoginField();
            req_user_login.UserID = "hdcx";
            req_user_login.Password = "hdcx";
            int ret = CThostFtdcMdApi.ReqUserLogin(ref req_user_login, 0);
            Console.WriteLine("ReqUserLogin, Return Code[{0}]", ret);
        }

        static CThostFtdcMdSpi m_md_spi;
        static IntPtr m_md_spi_point;
    }
}
