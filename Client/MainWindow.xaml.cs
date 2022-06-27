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
using System.Windows.Threading;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            workThread = new WorkThread(this);
            workThread.Init("127.0.0.1", 10000);
        }
        WorkThread workThread;
        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            workThread.Start();
        }

        private void disconnectButton_Click(object sender, RoutedEventArgs e)
        {
            workThread.Stop();
        }

        public void UpdateSendMessage(string message)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)delegate ()
            {
                sendData.Text += "\n" + message;
            });
        }
        public void UpdateRecvMessage(string message)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)delegate ()
            {
                recvData.Text += "\n" + message;
            });
        }

        private void MyWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            workThread.Stop();
            workThread.Join();
        }
    }
}
