/**
 * @file XBase.h
 * @since 2022/1/26
 */

#ifndef INCLUDE_XMAN_XBASE_H_
#define INCLUDE_XMAN_XBASE_H_
#include "XError.h"
#include "XTypes.h"

#ifdef __cplusplus
extern "C"
{
#endif

/** 无业务含义的函数返回值使用 */
typedef int XReturn;

/** 索引位置 */
typedef long long XIdx;

/** 行情里面流水号 */
typedef long long XSeqNum;

/** 价格 */
typedef int XPrice;

/** 单纯数量 */
typedef int XNum;

/** 比例 */
typedef int XRatio;

/** 报单数量 */
typedef int XQty;

/** 统计数量 */
typedef long long XSumQty;

/** 资金 */
typedef long long XMoney;

/** 单位 */
typedef unsigned int XUnit;

/** 费用 */
typedef int XFee;

/** 交易日 */
typedef int XTradeDay;

/** 短时间 */
typedef int XShortTime;

/** 长时间 */
typedef long long XLongTime;

/** 交易所报单编号 */
typedef long long XSystemId;

/** 本地报单编号 */
typedef int XLocalId;

/** 策略编号 */
typedef long long XPlotId;

/** 最大订阅行情数量 */
#define MAX_MKTSUB_CNT       20000

/** 证券代码长度 */
#define SECURITYID_LEN        16

/** 投资者账户/股东账户 */
#define INVESTID_LEN          16

/** 客户号长度 */
#define CUSTOMERID_LEN        16

/** 证券名称长度 */
#define SECURITYNAME_LEN      40

/** 资金账户长度 */
#define ACCOUNTID_LEN         16

/** 交易所订单编号长度 */
#define EXCHORDID_LEN         16

/** 错误信息长度 */
#define ERRORMSG_LEN          60

/** 频道号长度 */
#define CHANNEL_NO_LEN        3

/** ns到s的倍数 */
#define XTIMS_S4NS          (1000000000LL)

/** ns到ms的倍数 */
#define XTIMS_MS4NS         (1000000LL)

/** 实际的价格要除以10000 */
#define XPRICE_DIV     	     (10000.0)

/** 实际的价格 * 10000 */
#define XPRICE_MULT          (10000)

/**客户号 */
typedef char XCustomer[CUSTOMERID_LEN];

/** 股东帐户 */
typedef char XInvestId[INVESTID_LEN];

/** 资金账号 */
typedef char XAccountId[ACCOUNTID_LEN];

/** 证券代码 */
typedef char XSecurityId[SECURITYID_LEN];

/** 证券名称 */
typedef char XSecurityName[SECURITYNAME_LEN];

/** 行情流编号 */
typedef char XStreamId[CHANNEL_NO_LEN];

/** 密码 */
typedef char XPassword[128];

/** 会员代码 */
typedef char XBroker[10];

/** 硬盘序列号 */
typedef char XHardware[20];

/** 备注 */
typedef char XRemark[100];

/** 交易所订单编号 */
typedef char XExchId[EXCHORDID_LEN];

/** 错误信息 */
typedef char XErrMsg[ERRORMSG_LEN];

/** 日志信息 */
typedef char XLogMsg[500];

/** 内存配置文件目录 */
#define XSHM_SDB_FILE                   "../conf/sdb.conf"

#define XUSER_FILE                      "../conf/user.conf"

#ifdef __cplusplus
}
#endif

#endif /* INCLUDE_XMAN_XBASE_H_ */
