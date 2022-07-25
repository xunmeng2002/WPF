using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketClient
{
    public class OrderViewModel : PropertyChangedNotify
    {
        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();
        public bool? IsAllOrderSelected
        {
            get
            {
                var selected = Orders.Select(order => order.isSelected).Distinct().ToList();
                return selected.Count == 1 ? selected.Single() : null;
            }
            set
            {
                if (value != null)
                {
                    SelectAll(value.Value);
                    OnPropertyChanged();
                }
            }
        }
        private void SelectAll(bool select)
        {
            foreach (var order in Orders)
            {
                order.isSelected = select;
            }
        }
        public void AddOrder(Order order)
        {
            Orders.Add(order);
            order.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(order.isSelected))
                    OnPropertyChanged(nameof(IsAllOrderSelected));
            };
        }
        private void UpdateOrder(Order oldOrder, Order newOrder)
        {
            oldOrder.reqid = newOrder.reqid;
            oldOrder.envno = newOrder.envno;
            oldOrder.customerId = newOrder.customerId;
            oldOrder.investid = newOrder.investid;
            oldOrder.plotid = newOrder.plotid;
            oldOrder.localId = newOrder.localId;
            oldOrder.market = newOrder.market;
            oldOrder.securityId = newOrder.securityId;
            oldOrder.ordQty = newOrder.ordQty;
            oldOrder.ordPrice = newOrder.ordPrice;
            oldOrder.tradeQty = newOrder.tradeQty;
            oldOrder.tradeAvgPx = newOrder.tradeAvgPx;
            oldOrder.sendLocTime = newOrder.sendLocTime;
            oldOrder.cnfLocTime = newOrder.cnfLocTime;
            oldOrder.sendTime = newOrder.sendTime;
            oldOrder.cnfTime = newOrder.cnfTime;
            oldOrder.errorId = newOrder.errorId;
            oldOrder.errorMsg = newOrder.errorMsg;
        }
        public void OnRtnOrder(Order order)
        {
            AddOrder(order);
            //List<Order> orders = Orders.Where(o => o.localId == order.localId).ToList();
            //if (orders.Count > 0)
            //{
            //    Order oldOrder = orders.First();
            //    UpdateOrder(oldOrder, order);
            //}
            //else
            //{
            //    AddOrder(order);
            //}
        }
    }
}
