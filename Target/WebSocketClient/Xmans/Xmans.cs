using System;
using System.Collections.Generic;
using System.Text;


namespace WebSocketClient.Xmans
{
	public class ReqHeader
	{
		/// <summary>
		/// 
		/// </summary>
		public string msgtype{ get; set; } = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public long reqid{ get; set; } 
	}
	public class RspHeader
	{
		/// <summary>
		/// 
		/// </summary>
		public string msgtype{ get; set; } = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public long reqid{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public int errno{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public string errmsg{ get; set; } = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public int isEnd{ get; set; } 
	}
	public class RtnHeader
	{
		/// <summary>
		/// 
		/// </summary>
		public string msgtype{ get; set; } = string.Empty;
	}


	public class ReqLoginField
	{
		/// <summary>
		/// 
		/// </summary>
		public string userName{ get; set; }  = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public string password{ get; set; }  = string.Empty;
	}
	public class RspLoginField
	{
		/// <summary>
		/// 
		/// </summary>
		public string customerId{ get; set; }  = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public int tradeday{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public int updateTime{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public int Sessionid{ get; set; } 
	}
	public class ReqOrderField
	{
		/// <summary>
		/// 
		/// </summary>
		public string customerId{ get; set; }  = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public long frontId{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public int acctType{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public string investId{ get; set; }  = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public int market{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public string securityId{ get; set; }  = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public int bsType{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public int isCancel{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public int ordType{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public int ordQty{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public int ordPrice{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public int orgLocalId{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public int orgOrdId{ get; set; } 
	}
	public class OrderField
	{
		/// <summary>
		/// Id
		/// </summary>
		public long idx{ get; set; } 
		/// <summary>
		/// 客户环境号
		/// </summary>
		public int envno{ get; set; } 
		/// <summary>
		/// 柜台订单编号
		/// </summary>
		public long ordid{ get; set; } 
		/// <summary>
		/// 交易所订单编号
		/// </summary>
		public string exchordId{ get; set; }  = string.Empty;
		/// <summary>
		/// 冻结金额
		/// </summary>
		public long frzAmt{ get; set; } 
		/// <summary>
		/// 冻结费用
		/// </summary>
		public long frzFee{ get; set; } 
		/// <summary>
		/// 冻结持仓，发单时记录，收到确认和拒绝时解冻，同时根据此数量更新持仓中的locFrz
		/// </summary>
		public int locFrz{ get; set; } 
		/// <summary>
		/// 成交数量
		/// </summary>
		public int trdQty{ get; set; } 
		/// <summary>
		/// 成交金额
		/// </summary>
		public long trdMoney{ get; set; } 
		/// <summary>
		/// 产品类型
		/// </summary>
		public int productType{ get; set; } 
		/// <summary>
		/// 订单状态
		/// </summary>
		public int ordStatus{ get; set; } 
		/// <summary>
		/// 撤单的时候，如果因某系统未交易失败需要继续撤单
		/// </summary>
		public int exeStatus{ get; set; } 
		/// <summary>
		/// 对应使用哪家柜台;在适配器里面写死  
		/// </summary>
		public int counter{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public int _sendQty{ get; set; } 
		/// <summary>
		/// 本地发送时间(本地)
		/// </summary>
		public long _sendLocTime{ get; set; } 
		/// <summary>
		/// 委托时间(柜台)
		/// </summary>
		public long _sendTime{ get; set; } 
		/// <summary>
		/// 确认时间(本地)
		/// </summary>
		public long _cnfLocTime{ get; set; } 
		/// <summary>
		/// 确认时间(柜台)
		/// </summary>
		public long _cnfTime{ get; set; } 
		/// <summary>
		/// 请求编号，订单与请求对应
		/// </summary>
		public long reqId{ get; set; } 
		/// <summary>
		/// 会话ID
		/// </summary>
		public int sessionId{ get; set; } 
		/// <summary>
		/// 前端编号，同一个会话唯一
		/// </summary>
		public int frontId{ get; set; } 
		/// <summary>
		/// 客户号
		/// </summary>
		public string customerId{ get; set; }  = string.Empty;
		/// <summary>
		/// 股东账户如果未指定就自动获取第一个
		/// </summary>
		public string investId{ get; set; }  = string.Empty;
		/// <summary>
		/// 策略类型
		/// </summary>
		public int plotType{ get; set; } 
		/// <summary>
		/// 策略编号,前端生成
		/// </summary>
		public long plotid{ get; set; } 
		/// <summary>
		/// 客户委托流水号
		/// </summary>
		public int localId{ get; set; } 
		/// <summary>
		/// 客户撤单委托流水号
		/// </summary>
		public int clocalId{ get; set; } 
		/// <summary>
		/// 账户类型:现货,两融,期权
		/// </summary>
		public int acctType{ get; set; } 
		/// <summary>
		/// 买卖类型, 1:买;2:卖出
		/// </summary>
		public int bsType{ get; set; } 
		/// <summary>
		/// 撤单由该标志标识 1为撤单
		/// </summary>
		public int isCancel{ get; set; } 
		/// <summary>
		/// 订单类型,市价or限价
		/// </summary>
		public int ordType{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public string _Item{ get; set; }  = string.Empty;
		/// <summary>
		/// 市场
		/// </summary>
		public int market{ get; set; } 
		/// <summary>
		/// 证券代码
		/// </summary>
		public string securityId{ get; set; }  = string.Empty;
		/// <summary>
		/// 委托数量
		/// </summary>
		public int ordQty{ get; set; } 
		/// <summary>
		/// 委托价格
		/// </summary>
		public int ordPrice{ get; set; } 
		/// <summary>
		/// 环境号
		/// </summary>
		public int orgEnvno{ get; set; } 
		/// <summary>
		/// 撤单时原始订单编号
		/// </summary>
		public int orgLocalId{ get; set; } 
		/// <summary>
		/// 撤单时原始订单编号
		/// </summary>
		public long orgOrdId{ get; set; } 
		/// <summary>
		/// 下单时带入行情价格，后续进行比对
		/// </summary>
		public int _lastPx{ get; set; } 
		/// <summary>
		/// 下单时带入行情最新时间，后续进行比较
		/// </summary>
		public int _lastTime{ get; set; } 
	}
	public class ReqBasketField
	{
		/// <summary>
		/// 
		/// </summary>
		public string customerId{ get; set; }  = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public long frontId{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public int isForbid{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public int plotType{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public int zs{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public int cjb{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public int cdl{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public long wcjl{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public string formula{ get; set; }  = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public long gapTime{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public int beginTime{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public int endTime{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public string baskfile{ get; set; }  = string.Empty;
		/// <summary>
		/// 
		/// </summary>
		public long modSystemId{ get; set; } 
	}
	public class RspBasketField
	{
		/// <summary>
		/// 
		/// </summary>
		public long idx{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public int sessionId{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public long systemId{ get; set; } 
		/// <summary>
		/// 
		/// </summary>
		public ReqBasketField request{ get; set; } 
	}

	public class ReqLogin : ReqHeader
	{
		public List<ReqLoginField> data { get; set; } = new List<ReqLoginField>();
	}
	public class RspLogin : RspHeader
	{
		public List<RspLoginField> data { get; set; } = new List<RspLoginField>();
	}
	public class ReqOrder : ReqHeader
	{
		public List<ReqOrderField> data { get; set; } = new List<ReqOrderField>();
	}
	public class RspOrder : RspHeader
	{
		public List<OrderField> data { get; set; } = new List<OrderField>();
	}
	public class ReqBasket : ReqHeader
	{
		public List<ReqBasketField> data { get; set; } = new List<ReqBasketField>();
	}
	public class RspBasket : RspHeader
	{
		public List<RspBasketField> data { get; set; } = new List<RspBasketField>();
	}
}
