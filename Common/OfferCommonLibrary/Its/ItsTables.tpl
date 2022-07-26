using System;

namespace OfferCommonLibrary.Its
{
!!entry Its!!
!!travel!!
	public class Its!!@name!!
	{
		public Its!!@name!!(string[] items)
		{
!!entry items!!
!!travel!!
!!if @name != "ProtocolType" and @name != "Command":!!
!!inc indent!!
			!!@name!! = items[!!$pumpid!!];
!!dec indent!!
!!leave!!
!!leave!!
		}

!!entry items!!
!!travel!!
!!lowerName = @name[0].lower() + @name[1:]!!
!!if @name == "ProtocolType" or @name == "Command":!!
!!inc indent!!
		public static readonly string !!@name!! = "!!@value!!";
!!dec indent!!
!!else:!!
!!inc indent!!
		private string !!$lowerName!! = string.Empty;
!!dec indent!!
!!leave!!

!!travel!!
!!if @name != "ProtocolType" and @name != "Command":!!
!!inc indent!!
!!lowerName = @name[0].lower() + @name[1:]!!
		public string !!@name!!
		{ 
			get => !!$lowerName!!;
			set => !!$lowerName!! = value;
		}
!!dec indent!!
!!leave!!
		
		public override string ToString()
		{
			return !!travel!!!!if pumpid > 0:!!!!inc indent!! + "|" + !!dec indent!!!!@name!!!!leave!!;
		}
!!leave!!
	}
!!leave!!
!!leave!!
}
