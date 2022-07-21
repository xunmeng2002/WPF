using System;

namespace OfferCommon.Mdb
{
!!entry tables!!
!!travel!!
	public class !!@name!! : PropertyChangedNotify
	{
!!entry items!!
!!travel!!
!!lowerName = @name[0].lower() + @name[1:]!!
!!if @type == "string":!!
!!inc indent!!
		private !!@type!! !!$lowerName!! = string.Empty;
!!dec indent!!
!!elif @type == "enum":!!
!!inc indent!!
		private !!@name!! !!$lowerName!!;
!!dec indent!!
!!else:!!
!!inc indent!!
		private !!@type!! !!$lowerName!!;
!!dec indent!!
!!leave!!

!!travel!!
!!lowerName = @name[0].lower() + @name[1:]!!
!!if @type == "enum":!!
!!inc indent!!
		public !!@name!! !!@name!!
!!dec indent!!
!!else:!!
!!inc indent!!
		public !!@type!! !!@name!!
!!dec indent!!
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
!!leave!!
	}
!!leave!!
!!leave!!
}
