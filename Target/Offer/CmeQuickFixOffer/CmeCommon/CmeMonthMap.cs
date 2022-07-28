using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmeQuickFixOffer.CmeCommon
{
    public class CmeMonthMap
    {
        public static string GetMonthLetter(string month)
        {
            var it = m_CmeMonthMap.Where(item => item.Key == month).FirstOrDefault();
            return it.Value;
        }
        public static string GetMonthNum(string letter)
        {
            var it = m_CmeMonthMap.Where(item => item.Value == letter).FirstOrDefault();
            return it.Key;
        }

        private static Dictionary<string, string> m_CmeMonthMap { get; set; } = new Dictionary<string, string>
        {
            {"01", "F"},
            {"02", "G"},
            {"03", "H"},
            {"04", "J"},
            {"05", "K"},
            {"06", "M"},
            {"07", "N"},
            {"08", "Q"},
            {"09", "U"},
            {"10", "V"},
            {"11", "X"},
            {"12", "Z"}
        };
    }
}
