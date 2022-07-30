﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WebSocketClient.Mdb
{
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
