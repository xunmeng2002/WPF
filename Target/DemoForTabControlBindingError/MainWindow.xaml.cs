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

namespace DemoForTabControlBindingError
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            secondCheckBox.DataContext = orderViewModel;
            Button_Click(this, null);
            Button_Click(this, null);
            Button_Click(this, null);
        }
        public OrderViewModel orderViewModel { get; set; } = new OrderViewModel();

        private int maxReqid = 0;
        private int maxEnvno = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.IsSelected = false;
            order.Type = "reqOrder";
            order.Reqid = ++maxReqid;
            order.Envno = ++maxEnvno;
            orderViewModel.AddOrder(order);
        }
    }
}
