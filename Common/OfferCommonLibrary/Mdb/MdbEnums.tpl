using System;

namespace OfferCommonLibrary.Mdb
{
!!entry enums!!
!!travel!!
	public enum !!@name!!
	{
!!travel!!
		/// <summary>
		/// !!@desc!!
		/// </summary>
		!!@name!! = '!!@value!!',
!!leave!!
	}
!!leave!!
!!leave!!

	public class MdbConvertEnums
	{
!!entry enums!!
!!travel!!
!!lowerName = @name[0].lower() + @name[1:]!!
		public static !!@name!! ConvertTo!!@name!!(string !!$lowerName!!)
		{
			return (!!@name!!)(!!$lowerName!![0]);
		}
!!leave!!
!!leave!!
	}
}