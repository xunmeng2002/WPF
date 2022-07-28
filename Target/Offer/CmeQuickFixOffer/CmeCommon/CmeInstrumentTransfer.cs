using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmeQuickFixOffer.CmeCommon
{
	public class CmeInstrument
	{
		public string ExchangeID = "";
		public string InstrumentID = "";
		public string FixExchangeID = "";
		public string FixInstrumentID = "";
		public string ProductID = "";
		public string MaturityMonthYear = "";
	};

	public class CmeInstrumentTransfer
    {
		public static CmeInstrument GetFixInstrumentFromBroker(string exchangeID, string instrumentID)
        {
			var cmeInstrument = cmeInstruments.Where(cmeInstrument => cmeInstrument.ExchangeID == exchangeID && cmeInstrument.InstrumentID == instrumentID).FirstOrDefault();
			if(cmeInstrument == null)
            {
				
				string productID = instrumentID[..^4];
				string year = "20" + instrumentID.Substring(instrumentID.Length - 4, 2);
				string month = instrumentID.Substring(instrumentID.Length - 2, 2);
				string monthLetter = CmeMonthMap.GetMonthLetter(month);
				string fixInstrumentID = productID + monthLetter + year.Last();

				cmeInstrument = new CmeInstrument();
				cmeInstrument.ExchangeID = exchangeID;
				cmeInstrument.InstrumentID = instrumentID;
				cmeInstrument.FixExchangeID = exchangeID;
				cmeInstrument.FixInstrumentID = fixInstrumentID;
				cmeInstrument.ProductID = productID;
				cmeInstrument.MaturityMonthYear = year + month;
				cmeInstruments.Add(cmeInstrument);
			}
			return cmeInstrument;
		}
		public static CmeInstrument GetFixInstrumentFromExchange(string fixExchangeID, string fixInstrumentID)
        {
			var cmeInstrument = cmeInstruments.Where(cmeInstrument => cmeInstrument.FixExchangeID == fixExchangeID && cmeInstrument.FixInstrumentID == fixInstrumentID).FirstOrDefault();
			if (cmeInstrument == null)
			{
				int index = fixInstrumentID.IndexOfAny("0123456789".ToCharArray(), 0);
				string productID = fixInstrumentID.Substring(0, index - 1);
				string monthLetter = fixInstrumentID.Substring(index - 1, 1);
				string year = fixInstrumentID.Substring(index + 1);

				string monthNum = CmeMonthMap.GetMonthNum(monthLetter);
				string dateYear = DateTime.Now.ToString("yyyy");
				if (year.Length == 1)
                {
					year = dateYear.Substring(0, 3) + year;
                }
				else
                {
					year = dateYear.Substring(0, 2) + year;
				}
				string instrumentID = productID + year.Substring(2) + monthNum;

				cmeInstrument = new CmeInstrument();
				cmeInstrument.ExchangeID = fixExchangeID;
				cmeInstrument.InstrumentID = instrumentID;
				cmeInstrument.FixExchangeID = fixExchangeID;
				cmeInstrument.FixInstrumentID = fixInstrumentID;
				cmeInstrument.ProductID = productID;
				cmeInstrument.MaturityMonthYear = year + monthNum;
				cmeInstruments.Add(cmeInstrument);
			}
			return cmeInstrument;
		}
		public static CmeInstrument GetFixInstrumentFromProduct(string fixExchangeID, string productID, string maturityMonthYear)
        {
			var cmeInstrument = cmeInstruments.Where(cmeInstrument => cmeInstrument.FixExchangeID == fixExchangeID && cmeInstrument.ProductID == productID
			&& cmeInstrument.MaturityMonthYear == maturityMonthYear).FirstOrDefault();
			if (cmeInstrument == null)
			{
				string year = maturityMonthYear.Substring(0, 4);
				string month = maturityMonthYear.Substring(4);
				string monthLetter = CmeMonthMap.GetMonthLetter(month);
				string instrumentID = productID + year.Substring(2) + month;
				string fixInstrumentID = productID + monthLetter + year.Substring(3);

				cmeInstrument = new CmeInstrument();
				cmeInstrument.ExchangeID = fixExchangeID;
				cmeInstrument.InstrumentID = instrumentID;
				cmeInstrument.FixExchangeID = fixExchangeID;
				cmeInstrument.FixInstrumentID = fixInstrumentID;
				cmeInstrument.ProductID = productID;
				cmeInstrument.MaturityMonthYear = maturityMonthYear;
				cmeInstruments.Add(cmeInstrument);
			}
			return cmeInstrument;
		}

		private static List<CmeInstrument> cmeInstruments = new List<CmeInstrument>();
    }
}
