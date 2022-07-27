using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoForTabControlBindingError
{
    public class OrderViewModel : PropertyChangedNotify
    {
        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();
        public bool? IsAllOrderSelected
        {
            get
            {
                var selected = Orders.Select(order => order.IsSelected).Distinct().ToList();
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
                order.IsSelected = select;
            }
        }
        public void AddOrder(Order order)
        {
            Orders.Add(order);
            order.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(order.IsSelected))
                    OnPropertyChanged(nameof(IsAllOrderSelected));
            };
        }
    }
}
