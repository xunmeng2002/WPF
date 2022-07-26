/**
 * @file XDataStruct.h
 * @version 0.10.0 2022/3/15
 * 			- 初始版本
 * @since 2022/3/15
 */

#ifndef INCLUDE_XMAN_XDATASTRUCT_H_
#define INCLUDE_XMAN_XDATASTRUCT_H_
#include "XDataType.h"
#include "XStrategy.h"

#ifdef __cplusplus
extern "C"
{
#endif
#pragma pack(push,1)

/**
 * 证券黑名单信息数据
 */
typedef struct _XBlock {
	XNum type;                       	/**<  策略类型 */
	XChar market;					/**<  市场  @see eXMarket */
	XChar _field[3];
	XSecurityId securityId;				/**<  证券代码 */
} XBlockListT, *pXBlockListT;

typedef XBlockListT XMarketSecurityT;

typedef struct _XTransHead {
	XChar type;							/**< 数据传递的类型 */
	XChar _field[3];
	XNum dataLen;						/**< 数据传递的长度 */
	XIdx num;							/**< 传输序列号 */
} XTransHeadT, *pXTransHeadT;

/**********************************************************************************/

#define MAX_DEL_PRICELEVEL_CNT                   1000

/**
 * 行情监控信息
 */
typedef struct _XMonitorMd {
	XIdx idx;                                           	/**<  序号 */
	XTradeDay tradeday;                                  	/**<  交易日 */

	XIdx iMktSub;                                        	/**<  行情订阅数量 */
	XIdx iSnapshot;                                      	/**<  实际快照数（在静态数据中的数量） */
	XIdx iTick;												/**<  重建逐笔的数据  */
	XShortTime updatetime;                      			/**<  当前交易所时间 */
	XChar exchid;                                    		/**<  交易所  @see eXExchange */
	XChar Status;                                  			/**<  市场状态 @see eXMktStatus */
	XChar isRunnning;                                    	/**<  是否正常运行  */
	XChar _field[6];
	XShortTime gaptime;								 		/**<  时间差 */

	XIdx usedIdx;											/**<  最先用的删除位置  */
	XIdx delIdxs[MAX_DEL_PRICELEVEL_CNT];					/**< 保留价格档位的位置缓存 */
	XIdx delNums;											/**< 删除次数++ */
	XIdx maxPriceIdx;										/**<  最大的买位置  */

} XMonitorMdT, *pXMonitorMdT;

/**
 * 交易监控信息
*/
typedef struct _XMonitorTd {
	XIdx idx;                                           	/**<  序号 */
	XTradeDay tradeday;                                  	/**<  交易日 */
	XIdx iHolding;            								/**<  持仓条数  */
	XIdx iOrder;              								/**<  系统中订单的数量 */
	XIdx iDealPos;          								/**<  已处理委托数量 */
	XIdx iInvest;             								/**<  投资者账户数量 */
	XIdx iCashAsset;          								/**<  资金账户数量 */
	XIdx iStockInfo;                        				/**<  静态数据数量  */
	XIdx iIssue;                                 			/**<  发行业务证券数量 */
	XIdx iTrade;              								/**<  成交的条数 */
	XChar status;                                         	/**<  市场状态 (目前只取闭市状态) */
	XChar isInitOK;   							    		/**<  是否初始化OK */
	XChar isAcceptOK;                                 		/**<  是否可以接收委托 */
	XChar isSendPurchase;       					    	/**<  是否已经做了申购 */
	XLocalId iMaxLocalId;                        			/**<  最大本地编号,如果本地编号比服务器存储大，以本地为主  */
	XIdx iCurSendIdx;            							/**<  已发出委托的索引位置  */
} XMonitorTdT, *pXMonitorTdT;

#define MAX_CUSTOMER_CNT                20
#define MAX_EXCHANGE_CNT                10

/**
 * 交易+行情监控
 */
typedef struct _XMonitor {
	XIdx iTotalOrder;                                    /**<  委托总数  */
	XIdx iTotalTrade;                                    /**<  成交总数  */
	XIdx iTotalCustomer;                                 /**<  客户数  */
	XIdx iTotalInvest;                                   /**<  股东客户数  */
	XIdx iTotalCashAsset;                                /**<  资金账户数  */
	XIdx iTotalHolding;                                  /**<  持仓记录数  */
	XIdx iTotalStockInfo;                                /**<  证券信息  */
	XIdx iTotalIssue;                                    /**<  发行数据 */
	XIdx iTotalPlots;                                    /**<  策略数量  */

	XIdx iTotalSnapshot;                                 /**<  快照总数量 */
	XIdx iTotalTick;									 /**<  重建逐笔的数据 */
	XIdx iTickCounter;									 /**<  逐笔数据计数器 */
	XIdx iTickSnap;                                      /**< TickSnap计数器 */
	XIdx iTotalMd;                                       /**<  行情用户数 */
	XIdx iTotalTd;                                       /**<  交易用户数 */
	XIdx iBlock;                                  		 /**<  策略股票黑白名单 */
	XIdx iCounter;										 /**< 计数器 */
	XMonitorTdT monitorTd[MAX_CUSTOMER_CNT];        	 /**<  交易监控 */
	XMonitorMdT monitorMd[MAX_EXCHANGE_CNT];        	 /**<  行情监控 */
} XMonitorT, *pXMonitorT;
/***************************************************************************************/

#define MAX_STOCK_CNT    30000

/**
 * 静态数据信息
*/
typedef struct _XStock {
	XIdx idx;                                            	/**<  ID */
	XChar market;                                      		/**<  市场 @see eXMarket */
	XChar isPriceLimit;                               		/**<  是否有涨跌幅限制  */
	XChar isDayTrading;                               		/**<  是否回转交易  */
	XChar secStatus;                  						/**<  是否可以交易 @see eXSecStatus */
	XChar hasExBond;										/**<  是否有对应可转债 */
	XChar prdType;											/**<  产品类型 @see eXPrdType */
	XChar secType;                                      	/**<  证券类别 @see eXSecType  */
	XChar subSecType;                                 		/**<  证券子类别  @see eXSubSecType */

	XSecurityId securityId;                               	/**<  证券代码 */
	XSecurityName securityName;                           	/**<  证券名称 */
	XSecurityId baseSecurityId;                           	 /**<  基础证券代码 */

	XUnit buyUnit;                                        	 /**<  买基本单元 */
	XUnit sellUnit;                                       	 /**<  卖基本单元 */
	XQty mktBuyMaxQty;                                    	 /**<  市价最大买数量 */
	XQty mktBuyMinQty;										 /**<  市价最小买数量 */
	XQty mktSellMaxQty;										 /**<  市价最大卖数量 */
	XQty mktSellMinQty;										 /**<  市价最小卖数量 */
	XQty lmtbBuyMaxQty;									     /**<  现价最大买数量 */
	XQty lmtBuyMinQty;										 /**<  现价最小买数量 */
	XQty lmtSellMaxQty;									     /**<  现价最大卖数量 */
	XQty lmtSellMinQty;										 /**<  现价最小卖数量 */
	XPrice preClose;										 /**<  前收盘价 */
	XUnit priceTick;                                  		/**<  价格tick  */
	XPrice HighPrice;          								/**<  最高价  */
	XPrice LowPrice;           								/**<  最低价 */
	XSumQty outstandingShare;        						/**<  总股本 */
	XSumQty publicfloatShare;        						/**<  流通股本 */
	XPrice openHighPrice;                              		/**<  集合竞价最高价  */
	XPrice openLowPrice;                               		/**<  集合竞价最低价 */
	XTradeDay maturityDate;                 				/**<  可转债到期日  */
	XChar _field[4];
} XStockT, *pXStockT;

/**
 *  发行
*/
typedef struct _XIssue {
	XIdx idx;                                      		/**<  ID */
	XChar market;             							/**<  市场   @see eXMarket */
	XChar prdType;         								/**<  产品类型 @see eXPrdType */
	XChar issueType;           							/**<  issueType  @see eXIssType */
	XChar secType;        								/**<  证券类型 @see eXSecType */
	XChar _field;
	XChar subSecType;             						/**<  子证券类型 @see eXSubSecType  */
	XSecurityId securityId;     		           		/**<  发行代码 */
	XSecurityName securityName;     	           		/**<  证券名称 */
	XChar isCancel;            							/**<  是否允许撤单 */
	XChar isReapply;           							/**<  是否允许重复申购  */
	XChar _field1[2];
	XPrice issuePrice;          						/**<  发行价格 */
	XQty minQty;              							/**<  最小申购数量 */
	XQty maxQty;              							/**<  最大申购数量 */
	XUnit qtyUnit;             							/**<  委托数量单位 4 */
} XIssueT, *pXIssueT;

#define SNAPSHOT_PRICE_LEVEL_RANK                  10
#define MAX_RECENT_SNAPSHOT_CNT                    30
#define MARKET_STATIC_FREQ						   (1000)
/**
 * 快照
*/
typedef struct _XSnapshot {
	XIdx idx;                                              		/**<  ID */
	XChar market;                                          		/**<  市场  @see eXMarket */
	XChar mrkStatus;                          	    			/**<  市场状态  @see eXMktStatus */
	XChar secStatus;           									/**<  证券状态 @see eXSecStatus */
	XChar _field[5];

	XTradeDay tradeDate;										/**<  交易日 */
	XLongTime _locTime;											/**<  落地行情时时间 */
	XLongTime _genTime;											/**< 生成快照时间 */
	XSecurityId securityId;                          	    	/**<  证券代码  */
	XPrice preClosePx;                                     		/**<  前收盘价 */
	XPrice openPx;                                         		/**<  开盘价 */
	XPrice highPx;                                         		/**<  最高价 */
	XPrice lowPx;                                          		/**<  最低价 */
	XPrice tradePx;                                        		/**<  最新价 */
	XPrice vTradPx;												/**< 集合竞价虚拟成交价格 */
	XNum numTrades;        										/**<  成交笔数 */
	XShortTime updateTime;                                     	/**<  更新时间 */

	XSumQty volumeTrade;     									/**<  成交总量 */
	XMoney amountTrade;      									/**<  成交金额 */
	XPrice ask[SNAPSHOT_PRICE_LEVEL_RANK];                 		/**<  卖价 */
	XSumQty askqty[SNAPSHOT_PRICE_LEVEL_RANK];					/**<  卖量 */
	XSumQty askcqty[SNAPSHOT_PRICE_LEVEL_RANK];					/**< 撤单量 */
	XPrice bid[SNAPSHOT_PRICE_LEVEL_RANK];                  	/**<  买价 */
	XSumQty bidqty[SNAPSHOT_PRICE_LEVEL_RANK];					/**<  买量 */
	XSumQty bidcqty[SNAPSHOT_PRICE_LEVEL_RANK];					/**< 撤单量 */

	XLongTime lastTime;											/**< 最近一次行情时间 */
	XPrice lastPx;												/**< 最近一次成交价格 */
	XMoney lastAmt;												/**< 最近一次成交金额 */
	XSumQty lastQty;											/**< 最近一次成交数量 */

	XNum _lastTotal;												/**< 存储的次数 */
	XLongTime _lastTimes[MAX_RECENT_SNAPSHOT_CNT];				/**< 本地行情的时间 */
	XPrice _lastTradePrices[MAX_RECENT_SNAPSHOT_CNT];			/**< 成交价格 */
	XMoney _lastAmountTrade[MAX_RECENT_SNAPSHOT_CNT];        	/**< 成交金额 */
	XSumQty _lastTradeQties[MAX_RECENT_SNAPSHOT_CNT];			/**< 成交数量 */
	XSeqNum version;                                  			/**<  行情每更新一次记录 */
	XLongTime _avgOrder;										/**<  委托平均处理时间 */
	XLongTime _avgTrade;										/**< 逐笔成交平均处理时间 */
	XLongTime _avgSnap;											/**< 生成快照时间 */
	XInt _maxFndCnt;												/**< 最大查找次数 */
} XSnapshotT, *pXSnapshotT;

typedef XSnapshotT XTSnapshotT;									/**< 重构后的快照，前期先保持与交易所快照相同 */
/**
 * 逐笔委托数据
 */
typedef struct _TickOrder {
	XChar market;                                          		/**<  市场  @see eXMarket */
	XSecurityId securityId;                          	    	/**<  证券代码 */
	XNum traday;												/**< 交易日YYYYMMDD */
	XShortTime updateTime;										/**<  更新时间 HHMMSSsss*/
	XNum channel;												/**<  频道号 */
	XSeqNum bizIndex;											/**<  委托和成交连续编号 */
	XSeqNum ordSeq;												/**<  委托单独编号，只有上海除债券外行情 */
	XSeqNum seqno;												/**<  委托号 */
	/**
	 * 买卖方向
	 * - 深交所: '1'=买, '2'=卖, 'G'=借入, 'F'=出借
	 * - 上交所: '1'=买, '2'=卖
	 * @see eXBsType
	 */
	XChar bsType;

	XBool isCancel;									/**<  撤单由该标志标识 1为撤单 */
	/**
	 * 订单类型
	 * - 深交所: '1'=市价, '2'=限价, 'U'=本方最优
	 * - 上交所: 'A'=委托订单-增加(新订单), 'D'=委托订单-删除(撤单)
	 * @see eXOrdType
	 */
	XChar ordType;
	XChar _field[2];
	XPrice ordPx;										/**<  成交价格 */
	XQty ordQty;										/**<  订单数量 */
	XLongTime locTime;									/**<  落地行情时时间 */
} XTickOrderT, *pXTickOrderT;

/**
 * 逐笔成交
 */
typedef struct _XTickTrade {
	XChar market;                                        	/**<  市场  @see eXMarket  */
	XSecurityId securityId;                          	    /**<  证券代码  */
	XNum traday;											/**< 交易日YYYYMMDD */
	XShortTime updateTime;									/**<  更新时间 */
	XNum channel;											/**<  频道号 */
	XSeqNum bizIndex;										/**<  委托和成交连续编号 */
	XSeqNum tradeSeq;										/**<  成交单独编号,只有上海除债券外行情 */
	XSeqNum bidSeq;										    /**<  买委托号 */
	XSeqNum askSeq;											/**<  卖委托号 */

	XBool isCancel;											/**<  撤单由该标志标识 1为撤单 */
	XChar _filed[3];
	XPrice tradePx;											/**<  成交价格 */
	XQty tradeQty;
	XMoney tradeMoney;
	XLongTime locTime;										/**<  落地行情时时间 */
} XTickTradeT, *pXTickTradeT;

/**
 * 包含逐笔的缓存传输数据
 */
typedef struct _XL2L {
	XTransHeadT head;								/**<  通过消息头类型使用数据 */
	union {
		XSnapshotT snapshot;						/**<  快照 */
		XTickOrderT order;							/**<  逐笔委托 */
		XTickTradeT trade;							/**<  逐笔成交 */
	};
} XL2LT, *pXL2LT;


/**
 * 重构的丁单薄存储的委托信息
 */
typedef struct _XChannelOrder {
	XIdx idx;									/**<  id */
	XSecurityId securityId;						/**< 证券代码 */
	XSeqNum seqno;								/**<  交易所推送序号 */
	XNum channel;								/**<  频道号 */
	XChar bsType;								/**<  价格类型  @see eXBsType */
	XBool delFlag;								/**<  该笔委托是否删除  */
	XChar ordType;              				/**<  订单类型,市价or限价  @see eXOrdType */
	XChar market;                            	/**<  市场  @see eXMarket  */
	XPrice price;								/**<  价格 */
	XQty qty;									/**<  原始委托数量  */
	XQty leaveQty;								/**<  剩余数量  */
	XShortTime updateTime;						/**<  更新时间  */
	XLongTime locTime;							/**<  本地时间  */
	XChar _field[4];
	XIdx priceIdx;								/**<  价格链的位置,方便查找  */
	XULong _hash;
} XChannelOrderT, *pXChannelOrderT;

/**
 * 重构的订单薄的价格档位
 */
typedef struct _XPriceLevel {
	XIdx idx;					/**<  索引位置   */
	XIdx prev;					/***< 上一价格位置 */
	XIdx next;					/**< 下一价格位置 */
	struct level
	{
		XIdx forward;
		XIdx span;
	}level[5];

	XPrice price;				/**<  价格   */
	XChar _filed[4];
	XSumQty sumQty;				/**<  委托总量   */
	XSumQty sumCQty;			/**<  累计撤单数量 */
	XSumQty vBuySumQty;			/**< 虚拟成交数量，只在集合竞价有用 */
	XSumQty vSellSumQty;        /**< 虚拟成交数量 */
	XIdx vSellIdx;              /**< 虚拟成交时使用 */
	XIdx vBuyIdx;				/**< 虚拟成交时使用 */
	XNum numOrders;				/**<  委托订单数量   */
	XShortTime updateTime; 		/**<  最后更新时间   */
	XSecurityId _securityId;						/**< 证券代码 */
} XPriceLevelT, *pXPriceLevelT;

#ifndef _PRODCUT_TICK_DATA_
#define REAL_SNAPSHOT_PRICE_LEVEL    10000
#define REAL_SNAPSHOT_ORDER_CNT      1000
#define MAX_SNAPSHOT_STORE            30
#else
#define REAL_SNAPSHOT_PRICE_LEVEL    10000
#define REAL_SNAPSHOT_ORDER_CNT      30000
#define MAX_SNAPSHOT_STORE           30
#endif

typedef struct _RecentData {
	XQty tradeQties[MAX_SNAPSHOT_STORE];			/**< 存储的最大小大数量 */
	XNum bs[MAX_SNAPSHOT_STORE];
	XShortTime updatetime[MAX_SNAPSHOT_STORE];
} XRecentDataT;

/**
 * 重构订单薄
 */
typedef struct _XTickSnap {
	XIdx idx;                                          	/**<  ID */
	XSecurityId securityId;								/**<  证券代码 */
	XChar market;										/**<  市场 @see eXMarket  */
	XChar _filed1[3];
	XShortTime updateTime;								/**<  更新时间 */
	XShortTime ordTime;									/**< 交易所更新时间 */
	XPrice tradePx;										/**<  最新成交价格 */
	XSeqNum version;									/**<  版本 */
	XNum numOrders;										/**<  委托笔数 */
	XNum numTrades; 									/**<  成交笔数 */
	XSumQty volumeTrade;								/**<  成交数量 */
	XMoney amountTrade;									/**< 成交金额 */
	XLongTime locTime;									/**<  落地行情时间ns */
	XBool _isError;
	XChar _filed[3];
	XNum buyLevel;										/**< 价格档位层次 */
	XNum sellLevel;										/**< 价格档位层次 */
	XIdx buyLevelIdx;									/**< 买价格档位，从大到小 */
	XIdx sellLevelIdx;									/**< 卖价格档位, 从小到大 */
	XIdx needBuyTradeIdx;								/**< 买的价格大于卖一但是还未收到成交 */
	XIdx needSellTradeIdx;								/**< 卖的价格小于买一但是还未收到成交 */
//	XQty tradeQties[MAX_SNAPSHOT_STORE];				/**<  最近成交数量 */
//	XPrice tradePrices[MAX_SNAPSHOT_STORE];
	XLongTime _avgOrder;
	XLongTime _avgTrade;
	XLongTime _avgSnap;
	XInt _maxFndCnt;										/**< 最大寻找次数 */
} XTickSnapT, *pXTickSnapT;

typedef struct _XTickCache {
	XTransHeadT head;								/**<  通过消息头类型使用数据 */
	XTickSnapT ticksnap;							/**<  tickcache */
}XTickCacheT, *pXTickCacheT;
/******************************************************************************************/
/**
 * 账户数据单独管理
*/
typedef struct _XCust {
	XIdx idx;                                   /**<  编号 */
	XCustomer customerId;                       /**<  客户号+柜台唯一 */
	XChar counter;                          	/**<  柜台 */
	XChar type;                        			/**<  交易:0x01(1),行情:0x10(2),交易和行情:0x11(3) */
	XChar exchid;                          		/**<  交易所  @see eXExchange */
	XChar _field;
	XPassword password;                        /**<  密码 */
	XBroker broker;                           	/**<  券商 */
	XHardware hd;                             	/**<  硬盘序列号 */
	XRemark remark;                          	/**<  备注 */

} XCustT, *pXCustT;

/**
 * 子账户具有独立的资金账户及持仓信息
 */
typedef struct _XSubCust {
	XIdx idx;								/**<  子账户编号 */
	XIdx mainIdx;							/**<  主账户位置 */
	XPassword password;						/**<  子账户密码 */
} XSubCustT, *pXSubCustT;

/**
 * 股东账户信息
*/
typedef struct _XInvest {
	XIdx idx;                                   /**<  编号 */
	XCustomer customerId;      					/**<  客户号 */
	XSeqNum seqno;                              /**<  客户号下面投资者账户编号,客户号+seqno唯一 */
	XChar market;               				/**<  市场  @see eXMarket */
	XChar acctType;             				/**<  1:现货;2:两融;3:期权,4:期货,5:黄金 */
	XChar isMain;				            	/**<  主辅账户，同一市场+账户类型，主账户唯一 */
	XChar _field[5];
	XInvestId investId;        					/**<  股东账户，同一客户投资者不能重复 */
	XQty mainQuota;            					/**<  新股权益 */
	XQty kcQuota;              					/**<  科创板权益 */
} XInvestT, *pXInvestT;

/**
 * 资金账户信息
*/
typedef struct _XCash {
	XIdx idx;                                    	/**<  编号 */
	XCustomer customerId;    						/**<  客户号 */
	XSeqNum seqno;                             		/**<  资金账户编号，客户号+seqno唯一 */
	XChar acctType;           						/**<  0:现货;1:两融;2期权 */
	XChar isMain;                               	/**<  主辅账户，同一市场+账户类型，主账户唯一，辅账户可以有多个 */
	XChar _field[6];
	XAccountId accountId;     		           		/**<  资金账户 */
	XMoney beginBalance;      						/**<  日初资金 */
	XMoney beginAvailable;    						/**<  日初可用 */
	XMoney beginDrawable;     						/**<  日初可取 */
	XMoney frozenAmt;         						/**<  买冻结未成交资金 */
	XMoney curAvailable;         			    	/**<  当前可用 */
	XMoney totalBuy;                             	/**<  累计买费用 */
	XMoney totalSell;                            	/**<  累计卖费用 */
	XMoney totalFee;                             	/**<  累计交易费用 */
} XCashT, *pXCashT;

/**
 * 持仓账户信息
*/
typedef struct _XHold {
	XIdx idx;                              			/**<  编号 */
	XCustomer customerId;    						/**<  客户号 */
	XInvestId investId;     						/**<  股东帐户 */
	XChar market;            						/**<  市场 @see eXMarket */
	XChar _field[7];
	XSecurityId securityId;    						/**<  产品代码 */
	XSumQty orgHld;      							/**<  日初持仓 */
	XSumQty orgAvlHld;   							/**<  日初可用 */
	XMoney orgCostAmt; 								/**<  日初持仓成本 */
	XSumQty totalBuyHld;       						/**<  累计买 */
	XSumQty totalSellHld;      						/**<  累计卖 */
	XMoney totalBuyAmt;                      		/**<  累计买金额 */
	XMoney totalSellAmt;                     		/**<  累计卖金额 */
	XSumQty sellFrz;        						/**<  卖冻结 */
	XSumQty locFrz;									/**<  记录本地冻结持仓，系统重启时为0;发单时在Order记录冻结持仓数量,收到确认和拒绝时解冻 */
	XSumQty sumHld;                           		/**<  总持仓 */
	XSumQty sellAvlHld;     						/**<  可卖持仓 */
	XSumQty countSellAvlHld;						/**<  柜台可用持仓 */
	XSumQty etfAvlHld;      						/**<  可用于etf申购的持仓 */
	XPrice costPrice;      							/**<  持仓成本价 */
	XChar _field2[4];
} XHoldT, *pXHoldT;

/**
 * 订单请求
 */
typedef struct _XOrderReq {
	XIdx reqId;										/**< 请求编号，订单与请求对应 */
	XNum sessionId;									/**< 会话ID */
	XLocalId frontId;								/**< 前端编号，同一个会话唯一*/
	XCustomer customerId;     						/**<  客户号 16 */
	XInvestId investId;        						/**<  股东账户如果未指定就自动获取第一个 10 */
	XNum plotType;									/**<  策略类型 */
	XPlotId plotid;                               	/**<  策略编号,前端生成 */
	XLocalId localId;         						/**<  客户委托流水号  */
	XLocalId clocalId;         						/**<  客户撤单委托流水号  */
	XChar acctType;                          		/**<  账户类型:现货,两融,期权 @see eXInvType */
	XChar bsType;               					/**<  买卖类型, 1:买;2:卖出  @see eXBsType */
	XBool isCancel;									/**<  撤单由该标志标识 1为撤单 */
	XChar ordType;              					/**<  订单类型,市价or限价  @see eXOrdType */
	XChar _field[7];
	XChar market;            						/**<  市场 @see eXMarket */
	XSecurityId securityId;      					/**<  证券代码  */
	XQty ordQty;               						/**<  委托数量  */
	XPrice ordPrice;             					/**<  委托价格  */
	XNum orgEnvno;            						/**<  环境号  */
	XLocalId orgLocalId;     						/**<  撤单时原始订单编号  */
	XSystemId orgOrdId;     						/**<  撤单时原始订单编号  */
	XPrice _lastPx;									/**<  下单时带入行情价格，后续进行比对 */
	XShortTime _lastTime;							/**<  下单时带入行情最新时间，后续进行比较 */
} XOrderReqT, *pXOrderReqT;

/**
 * 委托信息
*/
typedef struct _XOrder {
	XIdx idx;                                  		/**<   Id */
	XNum envno;                						/**<  客户环境号 */
	XSystemId ordid;                				/**<  柜台订单编号 */
	XExchId exchordId;       						/**<  交易所订单编号  */
	XMoney frzAmt;               					/**<  冻结金额  */
	XMoney frzFee;               					/**<  冻结费用 */
	XQty locFrz;									/**<  冻结持仓，发单时记录，收到确认和拒绝时解冻，同时根据此数量更新持仓中的locFrz */
	XQty trdQty;               						/**<  成交数量  */
	XMoney trdMoney;								/**<  成交金额 */

	XChar productType;              				/**<  产品类型 @see eXPrdType  */
	XChar ordStatus;            					/**<  订单状态 @see eXOrdStatus */
	XChar exeStatus;                         		/**<  撤单的时候，如果因某系统未交易失败需要继续撤单 @see eXExecStatus */
	XChar counter;                           		/**<  对应使用哪家柜台;在适配器里面写死  */
	XChar _field[4];

	XLongTime sendLocTime;                          /**<  本地发送时间(本地)  */
	XLongTime sendTime;            					/**<  委托时间(柜台)  */
	XLongTime cnfLocTime;          					/**<  确认时间(本地)  */
	XLongTime cnfTime;           					/**<  确认时间(柜台)  */
	XNum errorno;              						/**<  错误原因  */
	XErrMsg errmsg;        				     	/**<  错误原因  */
	XOrderReqT request;                          	/**<  委托请求数据 */
} XOrderT, *pXOrderT;

/**
 * 成交信息
*/
typedef struct _XTrade {
	XIdx idx;                                           /**<  Id */
	XSystemId trdId;             					    /**<  成交编号 */
	XCustomer customerId; 								/**<  客户号 */
	XChar market;                                    	/**<  市场 @see eXMarket  */
	XChar trdSide;                                   	/**<  买卖方向 */
	XChar counter;                           			/**<  柜台 @see eXCounter */
	XChar _field;
	XShortTime trdTime;             					/**<  成交时间 HHMMSSSsss */

	XInvestId investId;       							/**<  股东帐户  */
	XSecurityId securityId;     						/**<  证券代码 */

	XQty trdQty;              							/**<  成交数量 */
	XPrice trdPrice;            						/**<  成交金额 */
	XMoney trdAmt;              						/**<  成交金额 */
	XSystemId ordid;               						/**<  柜台订单编号 */
} XTradeT, *pXTradeT;

/**
 * 交易数据缓存
 */
typedef struct _XTradeCache {
	XTransHeadT head;								/**<  通过消息头类型使用数据 */
	union {
		XOrderReqT ordreq;							/**< 订单请求 */
		XOrderT ordrsp;								/**<  委托 */
		XTradeT trade;								/**<  成交 */
		XHoldT hold;								/**<  持仓 */
		XCashT cash;								/**<  资金 */
		XStrategyT strategy;						/**< 策略 */
	};
} XTradeCache;

typedef struct _XSession
{
	XCustomer customerId; 								/**<  客户号 */
	XNum sessionId;										/**< 会话ID */
	XIdx frontId;										/**< 请求编号 */
}XSessionT;

#pragma pack(pop)

#ifdef __cplusplus

}
#endif

#endif /* INCLUDE_XMAN_XDATASTRUCT_H_ */
