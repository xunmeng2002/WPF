using System;
using System.Collections.Generic;
using System.Text;

namespace WebSocketClient.Mdb
{
!!entry Tables!!
!!travel!!
	public class !!@name!! : PropertyChangedNotify
	{
!!travel!!
!!lowerName = @name[0].lower() + @name[1:]!!
!!if @type == "string":!!
!!inc indent!!
		private !!@type!! !!$lowerName!! = string.Empty;
!!dec indent!!
!!else:!!
!!inc indent!!
		private !!@type!! !!$lowerName!!;
!!dec indent!!
		/// <summary>
		/// !!@desc!!
		/// </summary>
		public !!@type!! !!@name!!
		{
			get => !!$lowerName!!;
			set
			{
				if (!!$lowerName!! == value)
					return;
				!!$lowerName!! = value;
				OnPropertyChanged();
			}
		}
!!leave!!
	}
!!leave!!
!!leave!!
}
