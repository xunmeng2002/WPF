using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using QuickFix;

namespace CmeQuickFixOffer
{
    internal class Crypto
    {
        public static string GetCanonicalReq(Message messge)
        {
            string canonicalReq = "";
            if (messge.Header.IsSetField(QuickFix.Fields.Tags.MsgSeqNum))
            {
                canonicalReq += messge.Header.GetString(QuickFix.Fields.Tags.MsgSeqNum);
            }
            if (messge.Header.IsSetField(QuickFix.Fields.Tags.SenderCompID))
            {
                canonicalReq += "\n" + messge.Header.GetString(QuickFix.Fields.Tags.SenderCompID);
            }
            if (messge.Header.IsSetField(QuickFix.Fields.Tags.SenderSubID))
            {
                canonicalReq += "\n" + messge.Header.GetString(QuickFix.Fields.Tags.SenderSubID);
            }
            if (messge.Header.IsSetField(QuickFix.Fields.Tags.SendingTime))
            {
                canonicalReq += "\n" + messge.Header.GetString(QuickFix.Fields.Tags.SendingTime);
            }
            if (messge.Header.IsSetField(QuickFix.Fields.Tags.TargetSubID))
            {
                canonicalReq += "\n" + messge.Header.GetString(QuickFix.Fields.Tags.TargetSubID);
            }
            if (messge.IsSetField(QuickFix.Fields.Tags.HeartBtInt))
            {
                canonicalReq += "\n" + messge.GetString(QuickFix.Fields.Tags.HeartBtInt);
            }
            if (messge.Header.IsSetField(QuickFix.Fields.Tags.SenderLocationID))
            {
                canonicalReq += "\n" + messge.Header.GetString(QuickFix.Fields.Tags.SenderLocationID);
            }
            if (messge.Header.IsSetField(QuickFix.Fields.Tags.LastMsgSeqNumProcessed))
            {
                canonicalReq += "\n" + messge.Header.GetString(QuickFix.Fields.Tags.LastMsgSeqNumProcessed);
            }
            if (messge.IsSetField(1603)) //ApplicationSystemName
            {
                canonicalReq += "\n" + messge.GetString(1603);
            }
            if (messge.IsSetField(1604))    //ApplicationSystemVersion
            {
                canonicalReq += "\n" + messge.GetString(1604);
            }
            if (messge.IsSetField(1605))    //ApplicationSystemVendor
            {
                canonicalReq += "\n" + messge.GetString(1605);
            }
            Console.WriteLine("canonicalReq: [{0}]", canonicalReq);
            return canonicalReq;
        }

        public static string CalculateHMAC(string key, string canonicalReq)
        {
            byte[] decodeKey = UrlBase64.DecodeFromUtf8(key);

            HMACSHA256 hmac = new HMACSHA256(decodeKey);
            byte[] hashValue = hmac.ComputeHash(Encoding.UTF8.GetBytes(canonicalReq));

            return UrlBase64.EncodeToUtf8(hashValue);
        }
    }
}
