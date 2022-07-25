
/**  
 * @file: XStrategy.h
 * @Description: TODO(描述)
 * @author kangyq
 * @date 2022-07-11 10:45:46 
 */  
#ifndef INCLUDE_CORE_XSTRATEGY_H_
#define INCLUDE_CORE_XSTRATEGY_H_

#include "XDataType.h"

typedef enum _XStrategyType
{
	eXBasket = 1				/**< 篮子交易 */
}XStrategyType;

typedef struct _XBasket
{
	XNum zs;												/**< 涨速 */
	XNum cjb;												/**< 成交比 */
	XMoney cjje;											/**< 成交金额 */
	XNum cdl;												/**< 撤单率 */
	XSumQty wcjl;											/**< 未成交量 */
	XChar formula[50];										/**< 公式 */
	XChar baskfile[100];									/**< 篮子文件地址 */
}XBasketT,*pXBasketT;

#define MAX_GRID_LEVEL                 (20)
//策略数据
typedef struct _XStrategy
{
	XIdx idx;							/**< 编号 */
	XNum plotType;						/**< 策略类型 */
	XChar status;							/**< 策略执行状态 @see eXPlotStatus */
	XCustomer customerId;                   /**< 客户号 */
	XChar acctType;           				/**< 1:现货;2:两融;3期权;4:期货;5:黄金 4 */
	XPlotId plotid;							/**< 策略编号 */
	XNum frontId;							/**< 前端请求编号 */
	XNum envno;								/**< 先放着，后续想怎么维护方便 */
	XInvestId investId;						/**< 还未确认怎么添加到策略 */
	XChar market;						/**< 市场 */
	XSecurityId securityId;             /**<  证券代码 */
	XChar bsType;                       /**< 买卖方向 */
	XPrice ordPx;						/**< 委托价格 */
	XPrice conPx;						/**< 条件价格 */
	XQty ordQty;						/**< 委托数量 */

	XLongTime gapTime;					/**< 委托间隔 */
	XShortTime beginTime;				/**< 委托开始时间 */
	XShortTime endTime;					/**< 结束交易时间 */
	XNum sessionId;						/**< 会话编号 */

	XLocalId buyList[MAX_GRID_LEVEL];   /**< 买本地订单号 */
	XLocalId sellList[MAX_GRID_LEVEL];  /**< 卖本地订单号 */

	XSumQty buyTrades;					/**< 买成交 */
	XSumQty sellTrades;					/**< 卖成交 */
	XSeqNum version;					/**< 行情版本号 */
	union
	{
		XBasketT basket;

	};
	XSystemId systemId;
} XStrategyT;

typedef struct _XParams
{
	XCustomer customerId;                   				/**< 客户号 */
	XNum frontId;											/**< 前端请求编号 */
	XNum isForbid;											/**< 0:执行,1:停止 */
	XNum plotType;											/**< 策略类型 */
	XNum zs;												/**< 涨速 */
	XNum cjb;												/**< 成交比 */
	XNum cdl;												/**< 撤单率 */
	XSumQty wcjl;											/**< 未成交量 */
	XChar formula[50];										/**< 公式 */
	XLongTime gapTime;										/**< 委托间隔 */
	XShortTime beginTime;									/**< 委托开始时间 */
	XShortTime endTime;										/**< 结束交易时间 */

	XChar baskfile[100];									/**< 篮子文件地址 */

	XSystemId systemId;										/**< 每次策略后台给的编号 */

}XParamsT;


#endif /* INCLUDE_CORE_XSTRATEGY_H_ */
