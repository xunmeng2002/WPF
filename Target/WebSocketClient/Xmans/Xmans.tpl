using System;
using System.Collections.Generic;
using System.Text;


namespace WebSocketClient.Xmans
{
!!entry Hearders!!
!!travel!!
	public class !!@name!!
	{
!!travel!!
		/// <summary>
		/// !!@desc!!
		/// </summary>
!!if @type == "string":!!
!!inc indent!!
		public !!@type!! !!@name!! = string.Empty;
!!dec indent!!
!!else:!!
!!inc indent!!
		public !!@type!! !!@name!!;
!!dec indent!!
!!leave!!
	}
!!leave!!
!!leave!!


!!entry Fields!!
!!travel!!
	public class !!@name!!
	{
!!travel!!
		/// <summary>
		/// !!@desc!!
		/// </summary>
!!if @type == "string":!!
!!inc indent!!
		public !!@type!! !!@name!! = string.Empty;
!!dec indent!!
!!else:!!
!!inc indent!!
		public !!@type!! !!@name!!;
!!dec indent!!
!!leave!!
	}
!!leave!!
!!leave!!

!!entry Packages!!
!!travel!!
	public class !!@name!! : !!@header!!
	{
		public List<!!@data!!> data = new List<!!@data!!>();
	}
!!leave!!
!!leave!!
}
