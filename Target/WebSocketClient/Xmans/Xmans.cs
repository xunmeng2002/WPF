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
		public string? msgtype;
		/// <summary>
		/// 
		/// </summary>
		public long? reqid;
	}
	public class RspHeader
	{
		/// <summary>
		/// 
		/// </summary>
		public string? msgtype;
		/// <summary>
		/// 
		/// </summary>
		public long? reqid;
		/// <summary>
		/// 
		/// </summary>
		public int? errno;
		/// <summary>
		/// 
		/// </summary>
		public string? errmsg;
		/// <summary>
		/// 
		/// </summary>
		public int? isEnd;
	}
	public class RtnHeader
	{
		/// <summary>
		/// 
		/// </summary>
		public string? msgtype;
	}


	public class ReqLoginField
	{
		/// <summary>
		/// 
		/// </summary>
		public string? userName;
		/// <summary>
		/// 
		/// </summary>
		public string? password;
	}
	public class ReqOrderField
	{
		/// <summary>
		/// 
		/// </summary>
		public string? customerId;
		/// <summary>
		/// 
		/// </summary>
		public long? frontId;
		/// <summary>
		/// 
		/// </summary>
		public int? acctType;
		/// <summary>
		/// 
		/// </summary>
		public string? investId;
		/// <summary>
		/// 
		/// </summary>
		public int? market;
		/// <summary>
		/// 
		/// </summary>
		public string? securityId;
		/// <summary>
		/// 
		/// </summary>
		public int? bsType;
		/// <summary>
		/// 
		/// </summary>
		public int? isCancel;
		/// <summary>
		/// 
		/// </summary>
		public int? ordType;
		/// <summary>
		/// 
		/// </summary>
		public int? ordQty;
		/// <summary>
		/// 
		/// </summary>
		public int? ordPrice;
		/// <summary>
		/// 
		/// </summary>
		public int? orgLocalId;
		/// <summary>
		/// 
		/// </summary>
		public int? orgOrdId;
	}
	public class RspLoginField
	{
		/// <summary>
		/// 
		/// </summary>
		public string? customerId;
		/// <summary>
		/// 
		/// </summary>
		public int? tradeday;
		/// <summary>
		/// 
		/// </summary>
		public int? updateTime;
		/// <summary>
		/// 
		/// </summary>
		public int? Sessionid;
	}
	public class OrderField
	{
		/// <summary>
		/// Id
		/// </summary>
		public long? idx;
		/// <summary>
		/// 客户环境号
		/// </summary>
		public int? envno;
		/// <summary>
		/// 柜台订单编号
		/// </summary>
		public long? ordid;
		/// <summary>
		/// 交易所订单编号
		/// </summary>
		public string? exchordId;
		/// <summary>
		/// 冻结金额
		/// </summary>
		public long? frzAmt;
		/// <summary>
		/// 冻结费用
		/// </summary>
		public long? frzFee;
		/// <summary>
		/// 冻结持仓，发单时记录，收到确认和拒绝时解冻，同时根据此数量更新持仓中的locFrz
		/// </summary>
		public int? locFrz;
		/// <summary>
		/// 成交数量
		/// </summary>
		public int? trdQty;
		/// <summary>
		/// 成交金额
		/// </summary>
		public long? trdMoney;
		/// <summary>
		/// 产品类型
		/// </summary>
		public int? productType;
		/// <summary>
		/// 订单状态
		/// </summary>
		public int? ordStatus;
		/// <summary>
		/// 撤单的时候，如果因某系统未交易失败需要继续撤单
		/// </summary>
		public int? exeStatus;
		/// <summary>
		/// 对应使用哪家柜台;在适配器里面写死  
		/// </summary>
		public int? counter;
		/// <summary>
		/// 
		/// </summary>
		public int? _sendQty;
		/// <summary>
		/// 本地发送时间(本地)
		/// </summary>
		public long? _sendLocTime;
		/// <summary>
		/// 委托时间(柜台)
		/// </summary>
		public long? _sendTime;
		/// <summary>
		/// 确认时间(本地)
		/// </summary>
		public long? _cnfLocTime;
		/// <summary>
		/// 确认时间(柜台)
		/// </summary>
		public long? _cnfTime;
		/// <summary>
		/// 请求编号，订单与请求对应
		/// </summary>
		public long? reqId;
		/// <summary>
		/// 会话ID
		/// </summary>
		public int? sessionId;
		/// <summary>
		/// 前端编号，同一个会话唯一
		/// </summary>
		public int? frontId;
		/// <summary>
		/// 客户号
		/// </summary>
		public string? customerId;
		/// <summary>
		/// 股东账户如果未指定就自动获取第一个
		/// </summary>
		public string? investId;
		/// <summary>
		/// 策略类型
		/// </summary>
		public int? plotType;
		/// <summary>
		/// 策略编号,前端生成
		/// </summary>
		public long? plotid;
		/// <summary>
		/// 客户委托流水号
		/// </summary>
		public int? localId;
		/// <summary>
		/// 客户撤单委托流水号
		/// </summary>
		public int? clocalId;
		/// <summary>
		/// 账户类型:现货,两融,期权
		/// </summary>
		public int? acctType;
		/// <summary>
		/// 买卖类型, 1:买;2:卖出
		/// </summary>
		public int? bsType;
		/// <summary>
		/// 撤单由该标志标识 1为撤单
		/// </summary>
		public int? isCancel;
		/// <summary>
		/// 订单类型,市价or限价
		/// </summary>
		public int? ordType;
		/// <summary>
		/// 
		/// </summary>
		public string? _Item;
		/// <summary>
		/// 市场
		/// </summary>
		public int? market;
		/// <summary>
		/// 证券代码
		/// </summary>
		public string? securityId;
		/// <summary>
		/// 委托数量
		/// </summary>
		public int? ordQty;
		/// <summary>
		/// 委托价格
		/// </summary>
		public int? ordPrice;
		/// <summary>
		/// 环境号
		/// </summary>
		public int? orgEnvno;
		/// <summary>
		/// 撤单时原始订单编号
		/// </summary>
		public int? orgLocalId;
		/// <summary>
		/// 撤单时原始订单编号
		/// </summary>
		public long? orgOrdId;
		/// <summary>
		/// 下单时带入行情价格，后续进行比对
		/// </summary>
		public int? _lastPx;
		/// <summary>
		/// 下单时带入行情最新时间，后续进行比较
		/// </summary>
		public int? _lastTime;
	}

	public class ReqLogin : ReqHeader
	{
		public List<ReqLoginField> data = new List<ReqLoginField>();
	}
	public class ReqOrder : ReqHeader
	{
		public List<ReqOrderField> data = new List<ReqOrderField>();
	}
	public class RspLogin : RspHeader
	{
		public List<RspLoginField> data = new List<RspLoginField>();
	}
	public class RspOrder : RspHeader
	{
		public List<OrderField> data = new List<OrderField>();
	}
}
