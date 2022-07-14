using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Offer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            logger = serviceProvider.GetService<ILogger<MainWindow>>();
        }
        IServiceProvider serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
        
        LoggerFactory loggerFactory = new LoggerFactory();
        
        ILogger<MainWindow> logger;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            logger.Log(LogLevel.Information, "Hello World.");
        }
    }
}
