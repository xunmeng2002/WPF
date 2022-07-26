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
!!entry tables!!
!!travel!!
			AppService.AddSingleton<!!@name!!ViewModel>();
!!leave!!
!!leave!!
		}
	}

!!entry tables!!
!!travel!!
	public class !!@name!!ViewModel : PropertyChangedNotify
	{
		public ObservableCollection<!!@name!!> !!@name!!s { get; set; } = new ObservableCollection<!!@name!!>();
	}
!!leave!!
!!leave!!
}
