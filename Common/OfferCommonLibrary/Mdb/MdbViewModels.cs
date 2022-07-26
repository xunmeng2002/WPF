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
	}
	public class OrderViewModel : PropertyChangedNotify
	{
		public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();
	}
	public class OrderCancelViewModel : PropertyChangedNotify
	{
		public ObservableCollection<OrderCancel> OrderCancels { get; set; } = new ObservableCollection<OrderCancel>();
	}
	public class TradeViewModel : PropertyChangedNotify
	{
		public ObservableCollection<Trade> Trades { get; set; } = new ObservableCollection<Trade>();
	}
}
