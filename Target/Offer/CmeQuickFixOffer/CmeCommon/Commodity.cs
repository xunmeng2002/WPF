using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmeQuickFixOffer.CmeCommon
{
    public class CommodityRecord
    {
        public int CmeExchangeNo = 0;
        public string ExchangeID = "";
        public string ProductID = "";
        public int PoboExchangeNo = 0;
        public string PoboExchangeID = "";
        public string PoboProductID = "";
        public string ProductName = "";
        public int GroupID = 0;
        public int MagnificationFactor = 0;
        public int DecimalPlace = 0;
        public int DominantContractNo = 0;
    }
    public class Commodity
    {
        public static bool Load(string csvFileName)
        {
            StreamReader sr = new StreamReader(csvFileName);
            string? line = sr.ReadLine();   //丢弃第一行表头
            while((line = sr.ReadLine()) != null)
            {
                string[] items = line.Split(',');
                if(items.Length < 11)
                {
                    continue;
                }
                CommodityRecord commodityRecord = new CommodityRecord();
                commodityRecord.CmeExchangeNo = Convert.ToInt32(items[0]);
                commodityRecord.ExchangeID = items[1];
                commodityRecord.ProductID = items[2];
                commodityRecord.PoboExchangeNo = Convert.ToInt32(items[3]);
                commodityRecord.PoboExchangeID = items[4];
                commodityRecord.PoboProductID = items[5];
                commodityRecord.ProductName = items[6];
                commodityRecord.GroupID = Convert.ToInt32(items[7]);
                commodityRecord.MagnificationFactor = Convert.ToInt32(items[8]);
                commodityRecord.DecimalPlace = Convert.ToInt32(items[9]);
                commodityRecord.DominantContractNo = Convert.ToInt32(items[10]);

                m_CommodityRecords.Add(commodityRecord);
            }
            return true;
        }
        public static double GetCommodityPriceFactor(string exchangeID, string productID)
        {
            var item = m_CommodityRecords.Where(c => c.ExchangeID == exchangeID && c.ProductID == productID).FirstOrDefault();
            if (item == null)
            {
                return 1;
            }
            return Math.Pow(10, item.DecimalPlace);
        }

        static List<CommodityRecord> m_CommodityRecords = new List<CommodityRecord>();
    }
}
