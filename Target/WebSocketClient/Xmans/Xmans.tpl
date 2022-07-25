using System;
using System.Collections.Generic;
using System.Text;

namespace WebSocketClient
{
!!entry ReqPackages!!
!!travel!!
	public class !!@name!! : PropertyChangedNotify
	{
!!travel!!
!!lowerName = @name[0].lower() + @name[1:]!!
		public !!@type!!? !!$lowerName!! { get; set; }
!!leave!!
	}
!!leave!!
!!leave!!


!!entry RtnPackages!!
!!travel!!
	public class !!@name!! : PropertyChangedNotify
	{
!!travel!!
!!if @value == "":!!
!!inc indent!!
		private !!@type!!? !!@name!!;
!!dec indent!!
!!else:!!
!!inc indent!!
		private !!@type!!? !!@name!! = !!@value!!;
!!dec indent!!
!!lowerName = @name[0].lower() + @name[1:]!!
		public !!@type!!? !!$lowerName!!
		{
			get => !!@name!!;
			set
			{
				if (!!@name!! == value)
					return;
				!!@name!! = value;
				OnPropertyChanged();
			}
		}
!!leave!!
	}
!!leave!!
!!leave!!
}
