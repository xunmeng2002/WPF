using CommonLibrary;
using Microsoft.Extensions.Logging;
using OfferCommonLibrary.Its;
using OfferCommonLibrary.Mdb;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OfferCommonLibrary
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ILogger<MainWindow> logger, ItsEngine itsEngine, MdbEngine mdbEngine)
        {
            InitializeComponent();
            Logger = logger;
            m_ItsEngine = itsEngine;
            m_MdbEngine = mdbEngine;

            InitBindingData();
        }
        void InitBindingData()
        {
            itsConnectsDataGrid.ItemsSource = m_ItsEngine.m_Connects;
            gridOrders.ItemsSource = m_MdbEngine.m_OrderViewModel.Orders;
            gridOrderCancels.ItemsSource = m_MdbEngine.m_OrderCancelViewModel.OrderCancels;
            gridTrades.ItemsSource = m_MdbEngine.m_TradeViewModel.Trades;
            statusBlock.DataContext = m_MdbEngine;
        }

        private ILogger<MainWindow> Logger { get; set; }
        public ItsEngine m_ItsEngine { get; set; }
        public MdbEngine m_MdbEngine { get; set; }

    }
}

