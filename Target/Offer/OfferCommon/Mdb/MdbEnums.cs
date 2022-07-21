using System;

namespace OfferCommon.Mdb
{
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
	public enum HedgeFlag
	{
		/// <summary>
		/// 投机
		/// </summary>
		Speculation = '1',
		/// <summary>
		/// 套利
		/// </summary>
		Arbitrage = '2',
		/// <summary>
		/// 保值
		/// </summary>
		Hedge = '3',
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
	public enum OffsetFlag
	{
		/// <summary>
		/// 开仓
		/// </summary>
		Open = '0',
		/// <summary>
		/// 平仓
		/// </summary>
		Close = '1',
		/// <summary>
		/// 平今
		/// </summary>
		CloseToday = '2',
	}
	public enum ContingentCondition
	{
		/// <summary>
		/// 立即
		/// </summary>
		Immediately = '1',
		/// <summary>
		/// 止损
		/// </summary>
		Touch = '2',
		/// <summary>
		/// 止赢
		/// </summary>
		TouchProfit = '3',
		/// <summary>
		/// 预埋单
		/// </summary>
		ParkedOrder = '4',
	}
	public enum TimeCondition
	{
		/// <summary>
		/// 立即完成，否则撤销
		/// </summary>
		IOC = '1',
		/// <summary>
		/// 本节有效
		/// </summary>
		GFS = '2',
		/// <summary>
		/// 当日有效
		/// </summary>
		GFD = '3',
		/// <summary>
		/// 指定日期前有效
		/// </summary>
		GTD = '4',
		/// <summary>
		/// 撤销前有效
		/// </summary>
		GTC = '5',
		/// <summary>
		/// 集合竞价有效
		/// </summary>
		GFA = '6',
	}
	public enum VolumeCondition
	{
		/// <summary>
		/// 任何数量
		/// </summary>
		AV = '1',
		/// <summary>
		/// 最小数量
		/// </summary>
		MV = '2',
		/// <summary>
		/// 全部数量
		/// </summary>
		CV = '3',
	}
	public enum ForceCloseReason
	{
		/// <summary>
		/// 非强平
		/// </summary>
		NotForceClose = '0',
		/// <summary>
		/// 资金不足
		/// </summary>
		LackDeposit = '1',
		/// <summary>
		/// 客户超仓
		/// </summary>
		ClientOverPositionLimit = '2',
		/// <summary>
		/// 会员超仓
		/// </summary>
		MemberOverPositionLimit = '3',
		/// <summary>
		/// 持仓非整数倍
		/// </summary>
		NotMultiple = '4',
		/// <summary>
		/// 违规
		/// </summary>
		Violation = '5',
		/// <summary>
		/// 其它
		/// </summary>
		Other = '6',
		/// <summary>
		/// 自然人临近交割
		/// </summary>
		PersonDeliv = '7',
	}
	public enum TradeType
	{
		/// <summary>
		/// 普通成交
		/// </summary>
		Common = '0',
		/// <summary>
		/// 期权执行
		/// </summary>
		OptionsExecution = '1',
		/// <summary>
		/// OTC成交
		/// </summary>
		OTC = '2',
		/// <summary>
		/// 期转现衍生成交
		/// </summary>
		EFPDerived = '3',
		/// <summary>
		/// 组合衍生成交
		/// </summary>
		CombinationDerived = '4',
	}
	public enum MarginPriceType
	{
		/// <summary>
		/// 昨结算价
		/// </summary>
		PreSettlementPrice = '1',
		/// <summary>
		/// 最新价
		/// </summary>
		SettlementPrice = '2',
		/// <summary>
		/// 成交均价
		/// </summary>
		AveragePrice = '3',
		/// <summary>
		/// 开仓价
		/// </summary>
		OpenPrice = '4',
	}
	public enum IsLocalOrder
	{
		/// <summary>
		/// 外部
		/// </summary>
		Others = '0',
		/// <summary>
		/// 本地
		/// </summary>
		Local = '1',
	}
}