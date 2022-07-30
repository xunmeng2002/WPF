using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WebSocketClient.Mdb
{
!!entry Tables!!
!!travel!!
	public class !!@name!!ViewModel : PropertyChangedNotify
	{
		public ObservableCollection<!!@name!!> !!@name!!s { get; set; } = new ObservableCollection<!!@name!!>();
		public void Add(!!@name!! !!@name!!)
		{
			System.Windows.Application.Current.Dispatcher.Invoke(new Action(() => !!@name!!s.Add(!!@name!!)));
		}
		public void Remove(!!@name!! !!@name!!)
		{
			System.Windows.Application.Current.Dispatcher.Invoke(new Action(() => !!@name!!s.Remove(!!@name!!)));
		}
	}
!!leave!!
!!leave!!
}
