using System;
using System.Collections.Generic;
using System.Text;

namespace WebSocketClient.Mdb
{
	public enum Direction
	{
		/// <summary>
		/// 买
		/// </summary>
		Buy = '0',
		/// <summary>
		/// 卖
		/// </summary>
		Sell = '1',
	}
	public enum OrderPriceType
	{
		/// <summary>
		/// 市价
		/// </summary>
		Anyprice = '1',
		/// <summary>
		/// 限价
		/// </summary>
		LimitPrice = '2',
		/// <summary>
		/// 最优价
		/// </summary>
		BestPrice = '3',
		/// <summary>
		/// 最新价
		/// </summary>
		LastPrice = '4',
	}
	public enum OrderStatus
	{
		/// <summary>
		/// 正在申报
		/// </summary>
		Inserting = '0',
		/// <summary>
		/// 已报
		/// </summary>
		Inserted = '1',
		/// <summary>
		/// 部成
		/// </summary>
		PartTraded = '2',
		/// <summary>
		/// 已成
		/// </summary>
		AllTraded = '3',
		/// <summary>
		/// 已撤
		/// </summary>
		Canceled = '4',
		/// <summary>
		/// 部成部撤
		/// </summary>
		PartTradedCanceled = '5',
		/// <summary>
		/// 废单
		/// </summary>
		Error = 'e',
		/// <summary>
		/// 未触发
		/// </summary>
		NotTouched = 'p',
		/// <summary>
		/// 已触发
		/// </summary>
		Touched = 't',
		/// <summary>
		/// 未知
		/// </summary>
		Unknown = 'x',
	}
}