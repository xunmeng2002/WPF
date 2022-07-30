using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace OfferCommonLibrary.Mdb
{
	public class MdbViewModelInit
	{
		public static void Init(IServiceCollection AppService)
        {
			AppService.AddSingleton<OrderSequenceViewModel>();
			AppService.AddSingleton<OrderViewModel>();
			AppService.AddSingleton<OrderCancelViewModel>();
			AppService.AddSingleton<TradeViewModel>();
		}
	}

	public class OrderSequenceViewModel : PropertyChangedNotify
	{
		public ObservableCollection<OrderSequence> OrderSequences { get; set; } = new ObservableCollection<OrderSequence>();
		public void Add(OrderSequence OrderSequence)
		{
			System.Windows.Application.Current.Dispatcher.Invoke(new Action(() => OrderSequences.Add(OrderSequence)));
		}
		public void Remove(OrderSequence OrderSequence)
		{
			System.Windows.Application.Current.Dispatcher.Invoke(new Action(() => OrderSequences.Remove(OrderSequence)));
		}
	}
	public class OrderViewModel : PropertyChangedNotify
	{
		public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();
		public void Add(Order Order)
		{
			System.Windows.Application.Current.Dispatcher.Invoke(new Action(() => Orders.Add(Order)));
		}
		public void Remove(Order Order)
		{
			System.Windows.Application.Current.Dispatcher.Invoke(new Action(() => Orders.Remove(Order)));
		}
	}
	public class OrderCancelViewModel : PropertyChangedNotify
	{
		public ObservableCollection<OrderCancel> OrderCancels { get; set; } = new ObservableCollection<OrderCancel>();
		public void Add(OrderCancel OrderCancel)
		{
			System.Windows.Application.Current.Dispatcher.Invoke(new Action(() => OrderCancels.Add(OrderCancel)));
		}
		public void Remove(OrderCancel OrderCancel)
		{
			System.Windows.Application.Current.Dispatcher.Invoke(new Action(() => OrderCancels.Remove(OrderCancel)));
		}
	}
	public class TradeViewModel : PropertyChangedNotify
	{
		public ObservableCollection<Trade> Trades { get; set; } = new ObservableCollection<Trade>();
		public void Add(Trade Trade)
		{
			System.Windows.Application.Current.Dispatcher.Invoke(new Action(() => Trades.Add(Trade)));
		}
		public void Remove(Trade Trade)
		{
			System.Windows.Application.Current.Dispatcher.Invoke(new Action(() => Trades.Remove(Trade)));
		}
	}
}
