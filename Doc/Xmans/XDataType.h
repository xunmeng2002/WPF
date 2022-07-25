/**
 * @file XDataType.h
 * @since 2022/3/15
 */

#ifndef INCLUDE_XMAN_XDATATYPE_H_
#define INCLUDE_XMAN_XDATATYPE_H_

#include "XBase.h"

#ifdef __cplusplus
extern "C"
{
#endif

/**
 * 用户类型
 */
typedef enum _eXUserType {
	eXUserTrade = '1', 				/**< 单交易 */
	eXUserMarket = '2', 			/**< 单行情 */
	eXUserBoth = '3'				/**< 交易和行情 */
} eXUserType;

/**
 * 柜台
 */
typedef enum _eCounter {
	eXCounterOes = '1', 					/**< OES */
	eXCounterCtp = '2', 					/**< CTP */
	eXCounterXtp = '3'					/**< XTP */
} eXCounter;

/**
 * 交易所
 */
typedef enum _eXExchange {
	eXExchSse = '1', 						/**< 上交所 */
	eXExchSze = '2',						/**< 深交所 */
	eXExchSec = '3',                      /**< 沪深交易所 */
	eXExchCcef = '4',						/**< 中金所 */
} eXExchange;

/**
 * 市场
 */
typedef enum _eXMarket {
	eXMarketSha = '1',                   /**< 上海A */
	eXMarketSza = '2'                    /**< 深圳A */
} eXMarket;

/**
 * 买卖方向
 */
typedef enum _eXBsType	{
	eXBuy = '1',					/**< 买 */
	eXSell = '2', 					/**< 卖 */
	eXCBuy = '3',     				/**< 融资买 */
	eXCSell = '4',   				/**< 融券卖 */
	eXDeem = '5',					/**< 申购 */
	eXRedeem = '6',					/**< 赎回 */
	/** 行情专属字段 */
	eXMktBsG = 'G',					/**< 'G' - 借入 */
	eXMktBsF = 'F'                	/**< 'F' - 出借 */
} eXBsType;

/**
 * 投资者账户类型
 */
typedef enum _eXInvType {
	eXInvSpot = '1',            /**< 现货 */
	eXInvCrd = '2',              /**< 两融 */
	eXInvOpt = '3',             /**< 期权 */
	eXInvFtr = '4',             /**< 期货 */
} eXInvType;

/**
 * 市场状态
 */
typedef enum _XMktStatus {
	eXMktPreOpen = '1',               /**< 开始前 */
	eXMktCallAuct = '2',              /**< 集合竞价 */
	eXMktPause = '3',                 /**< 休市 */
	eXMktConAuct = '4',               /**< 连续竞价 */
	eXMktClosing = '5',               /**< 15收盘 */
	eXMktClosed = '6'                /**< 闭市 15:30 */
} eXMktStatus;

/**
 * 证券状态
 */
typedef enum _eXSecStatus {
	eXSecTrading = '1',              /**< 交易 */
	eXSecPause = '2',                /**< 全天停牌 */
	eXSecTmpPause = '3',             /**< 临时停牌 */
	eXSecFirstTrading = '4',         /**< 上市首日 */
	eXSecST = '5',                   /**< ST, *ST */
	eXSecDiv = '6',                  /**< 除权除息 */
	eXSecDList = '7',                 /**< 退市 */
	eXSecNewList = '8'                /**< 上市前期 */
} eXSecStatus;

/**
 * 产品类型
 */
typedef enum _eXPrdType {
	eXEquity = 0,                  /**< 普通股票、债券、基金、科创板、存托凭证买卖 */
	eXBondPR = '2',                  /**< 债券质押式回购 */
	eXIPO = '3',                     /**< 新股认购 */
	eXAllot = '4',               	/**< 配股 */
	eXOption = '5',                  /**< 期权 */
} eXPrdType;

/**
 * 证券类型
 */
typedef enum _eXSecType {
	eXStock = '1',                   /**< 股票 */
	eXBond = '2',                    /**< 债券 */
	eXFund = '3',                    /**< 基金(不包括Etf) */
	eXETF = '4',                     /**< ETF */
	eXOpt = '5'                      /**< 期权 */
} eXSecType;

/**
 * 证券子类型
 */
typedef enum _eXSubSecType {
	eXSubSecASH = '1',             /**< A 股票 */
	eXSubSecSME = '2',             /**<  中小板 */
	eXSubSecGEM = '3',             /**< 创业板 */
	eXSubSecKSH = '4',             /**< 科创板 */
	eXSubSecKCDR = '5',            /**< 科创板CDR */
	eXSubSecCDR = '6',             /**< 存托凭证 */
	eXSubSecHLT = '7',             /**< 沪伦通 */

	eXSubSecGBF = 'a',            /**< 国债 */
	eXSubSecCBF = 'b',            /**< 企业债 */
	eXSubSecCPF = 'c',            /**< 公司债 */
	eXSubSecCCF = 'd',            /**< 可转换债 */
	eXSubSecFBF = 'e',            /**< 金融机构发行债券 */
	eXSubSecPRP = 'f',            /**< 债券质押式回购 */

	eXSubSecSNGLETF = 'A',       /**< 单市场ETF */
	eXSubSecCRSETF = 'B',             /**< 跨市场ETF */
	eXSubSecBNDETF = 'C',             /**< 实物债券ETF */
	eXSubSecCRYETF = 'D',             /**< 货币ETF */
	eXSubSecCRFETF = 'E',             /**< 跨境ETF */
	eXSubSecGLDETF = 'F',             /**< 黄金ETF */
	eXSubSecPRDETF = 'G',             /**< 商品ETF */

	eXSubSecLOF = 'H',            /**< LOF基金 */
	eXSubSecCEF = 'I',                 /**< 封闭式基金 */
	eXSubSecOEF = 'J',                 /**< 开放式基金 */
	eXSubSecGRD = 'K',                 /**< 分级基金 */

	eXSubSecETFOPT = 'X',        /**< ETF期权 */
	eXSubSecSTKOPT = 'Y'             /**< 个股期权 */
} eXSubSecType;

/**
 * 订单类型
 */
typedef enum _eXOrdType {
	eXOrdLimit = '1',              /**< 限价 */
	eXOrdBest5 = '2',              /**< 最优5档即时成交剩余转限价 */
	eXOrdBest = '3',               /**< 对手方最优，仅科创板 */
	eXOrdBestParty = '4',          /**< 本方最优 ，仅科创板 */
	eXOrdBest5FAK = '5',           /**< 最优五档即时成交剩余撤销 */
	eXOrdLmtFOK = '6',             /**< 限价FOK,仅期权 */
	eXOrdMktFOK = '7',             /**< 市价FOK */
	eXOrdFAK = '8',                /**< 即时成交剩余撤销 */

	/*  以下为行情专属字段*/
	eXOrdMkt = 'A',               /**< 行情中市价 */
	eXOrdSelf = 'B',               /**< 本方最优 */

	eXOrdAdd = 'D',                /**< 对于上海行情为添加 */
	eXOrdDel = 'F'                 /**< 对于上海行情为删除 */
} eXOrdType;

/**
 * 订单状态
 */
typedef enum _eXOrdStatus {
	eXOrdStatusDefalut = '0', 	  /**< 默认 */
	eXOrdStatusNew = '1',         /**< 新订单 */
	eXOrdStatusDeclared = '2',    /**< 已确认 */
	eXOrdStatusPFilled = '3',     /**< 部分成交 */
	eXOrdStatusFilled = '4',      /**< 全部成交 */
	eXOrdStatusPCanceled = '5',   /**< 部分成交部分撤单 */
	eXOrdStatusCanceled = '6',    /**< 已撤 */
	eXOrdStatusInvalid = '7'      /**< 废单 */
} eXOrdStatus;

/**
 * 订单执行状态
 */
typedef enum _eXExecStatus {
	eXExecNone = '0',      /**< 未执行 */
	eXExecRisk = '2',      /**< 通过风控检查 */
	eXExec = '3',           /**< 已执行 */
	eXExecFailure = '9'         /**< 发送失败 */
} eXExecStatus;

/**
 * 发行方式
 */
typedef enum _eXIssType {
	eXIssQuota = '1',             /**< 额度 新股 */
	eXIssCash = '2',              /**< 资金 公开增发类 */
	eXIssCredit = '3',            /**< 信用 新债 */
	eXIssAllot = '4'              /**< 配股配债,即要检查持仓,又要检查资金 */
} eXIssType;

/**
 * 策略状态
 */
typedef enum _eXPlotStatus {
	eXPlotInit = '0',          		/**< 未初始化 */
	eXPlotNormal = '1',             	/**< 正常 */
	eXPlotPause = '2',              	/**< 暂停，可以再继续交易 */
	eXPlotStop = '3',              	/**< 停止,该状态在进行策略平仓操作 */
	eXPlotSuspend = '9',             /**< 终止 */
	eXPlotResume = 'A',             /**< 重新开始，趋势策略为重新计算均价 */
} eXPlotStatus;

/**
 * 延迟情况
 */
typedef enum _eXDelay {
	eXDelayNone = 0,      		/**< 不延迟 */
	eXDelayBuy = (1 << 0),       /**< 卖 */
	eXDelaySell = (1 << 1),      /**< 卖 */
	eXDelayBoth = (1 << 2),   /**< 买卖 */

} eXDelay;

/**
 * 禁止买卖标志
 */
typedef enum _eXBlockType {
	eXBlockNone = '0',     /**< 允许买卖 */
	eXBlockSell = '1',     /**< 禁止卖 */
	eXBlockBuy = '2',      /**< 禁止买 */
	eXBlockBoth = '3',     /**< 禁止买卖 */
} eXBlockType;

/**
 *	缓存数据类型
 */
typedef enum _eXDataType {
	eXDataCust = '0',			 /**< 客户数据 */
	eXDataStock = '1',			 /**< 证券信息数据 */
	eXDataInvest = '2',		 	/**< 投资者数据 */
	eXDataCash = '3',			 /**< 资金数据 */
	eXDataHold = '4',			 /**< 持仓数据 */
	eXDataIssue = '5',			 /**< 发行数据 */
	eXDataOrderReq = '6',        /**< 订单请求 */
	eXDataOrder = '7',			/**< 委托 */
	eXDataTrade = '8',			/**< 成交 */

	eXDataTickOrder = 'A',		 /**< 逐笔委托 */
	eXDataTickTrade = 'B',		 /**< 逐笔成交 */
	eXDataSnapshot = 'C',		 /**< 快照 */
	eXDataStatus = 'D',		 	/**< 行情状态 */
	eXDataTickSnap = 'E',       /**< 重构后的快照行情 */

	eXDataPlot = 'G',			/**< 策略 */
	eXDataBlock = 'H',    		/**< 黑名单证券 */
	eXDataTdMonitor = 'I',      /**< 交易监控 */
	eXDataMdMonitor = 'J',      /**< 行情监控 */
	eXDataTrans = 'K',			/**< 交易数据 */
	eXDataCounter = 'L',		/**< 计数器 */
	eXTickSnap = 'M'			/**< 计数器 */
} eXDataType;

/**
 * 逐笔成交(深圳：撤单or成交)
 */
typedef enum _eXL2ExeType {
	eXL2ExecCancel = '4',     /**< 撤销 '4' */
	eXL2ExecTrade = 'F'       /**< 成交 'F' */
} eXL2ExecType;

typedef enum _eMktSubType
{
	eMktSubAdd = '1',        /**< 订阅  */
	eMktSudDel = '2',        /**< 删除 */
	eMktSubReset = '3'       /**< 重新订阅 */
}eMktSubType;

#ifdef __cplusplus
}
#endif
#endif /* INCLUDE_XMAN_XDATATYPE_H_ */
