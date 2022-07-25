using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketClient.ViewModels
{
    public class CanCancelOrderViewModel : PropertyChangedNotify
    {
        public ObservableCollection<Order> CanCancelOrders { get; set; } = new ObservableCollection<Order>();
        public bool? IsAllCanCancelOrderSelect
        {
            get
            {
                var selected = CanCancelOrders.Select(order => order.isSelected).Distinct().ToList();
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
            foreach (var order in CanCancelOrders)
            {
                order.isSelected = select;
            }
        }
        public bool CheckOrderStatus(Order order)
        {
            return order.orderStatus != 3;
        }
        public void AddOrder(Order order)
        {
            if(!CheckOrderStatus(order))
            {
                return;
            }
            CanCancelOrders.Add(order);
            order.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(order.isSelected))
                    OnPropertyChanged(nameof(IsAllCanCancelOrderSelect));
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
            List<Order> orders = CanCancelOrders.Where(o => o.localId == order.localId).ToList();
            if (orders.Count > 0)
            {
                Order oldOrder = orders.First();
                
                if (order.orderStatus == 3)
                {
                    return;
                }
                UpdateOrder(oldOrder, order);
            }
            else
            {
                AddOrder(order);
            }
        }
    }
}
