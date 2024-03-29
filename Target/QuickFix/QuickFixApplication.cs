﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickFix;

namespace CmeQuickFix
{
    internal class QuickFixApplication : QuickFix.MessageCracker, QuickFix.IApplication
    {
        public void Init(Config config, IInitiator initiator)
        {
            AppConfig = config;
            MyInitiator = initiator;
        }
        Session? MySession = null;
        // This variable is a kludge for developer test purposes.  Don't do this on a production application.
        public IInitiator? MyInitiator;
        public Config AppConfig = new Config();

        #region IApplication interface overrides
        public void OnCreate(SessionID sessionID)
        {
            MySession = Session.LookupSession(sessionID);
            MySession.CheckCompID = false;
        }
        public void OnLogout(SessionID sessionID)
        {
            Console.WriteLine("Logout - " + sessionID.ToString());
        }
        public void OnLogon(SessionID sessionID)
        {
            Console.WriteLine("Logon - " + sessionID.ToString());
        }

        public void FromAdmin(Message message, SessionID sessionID)
        {
            Console.WriteLine("IN:  " + message.ToString());
            try
            {
                Crack(message, sessionID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("==Cracker exception==");
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
            }
        }
        public void ToAdmin(Message message, SessionID sessionID)
        {
            string msgType = message.Header.GetString(QuickFix.Fields.Tags.MsgType);
            if (msgType == QuickFix.FIX42.Logon.MsgType)
            {
                message.SetField(new QuickFix.Fields.ResetSeqNumFlag(false));
                message.Header.SetField(new QuickFix.Fields.SenderCompID(AppConfig.LoginSenderCompID));
                message.SetField(new QuickFix.Fields.StringField(1603, AppConfig.ApplicationSystemName));
                message.SetField(new QuickFix.Fields.StringField(1604, AppConfig.ApplicationSystemVersion));
                message.SetField(new QuickFix.Fields.StringField(1605, AppConfig.ApplicationSystemVendor));

                message.SetField(new QuickFix.Fields.IntField(354, AppConfig.AccessID.Length));
                message.SetField(new QuickFix.Fields.StringField(355, AppConfig.AccessID));
                message.SetField(new QuickFix.Fields.StringField(1400, AppConfig.EncryptedPasswordMethod));

                string canonicalReq = Crypto.GetCanonicalReq(message);
                string encodeHmac = Crypto.CalculateHMAC(AppConfig.SecretKey, canonicalReq);
                message.SetField(new QuickFix.Fields.IntField(1401, encodeHmac.Length));
                message.SetField(new QuickFix.Fields.StringField(1402, encodeHmac));
            }
            Console.WriteLine("OUT:  " + message.ToString());
        }
        public void FromApp(Message message, SessionID sessionID)
        {
            Console.WriteLine("IN:  " + message.ToString());
            try
            {
                Crack(message, sessionID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("==Cracker exception==");
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.StackTrace);
            }
        }
        public void ToApp(Message message, SessionID sessionID)
        {
            try
            {
                bool possDupFlag = false;
                if (message.Header.IsSetField(QuickFix.Fields.Tags.PossDupFlag))
                {
                    possDupFlag = QuickFix.Fields.Converters.BoolConverter.Convert(
                        message.Header.GetString(QuickFix.Fields.Tags.PossDupFlag)); /// FIXME
                }
                if (possDupFlag)
                    throw new DoNotSend();
            }
            catch (FieldNotFoundException)
            { }
            Console.WriteLine();
            Console.WriteLine("OUT: " + message.ToString());
        }
        #endregion

        #region MessageCracker handlers
        public void OnMessage(QuickFix.FIX42.Heartbeat m, SessionID s)
        {
            Console.WriteLine(m.ToString());
        }
        public void OnMessage(QuickFix.FIX42.TestRequest m, SessionID s)
        {
            Console.WriteLine(m.ToString());
        }
        public void OnMessage(QuickFix.FIX42.ResendRequest m, SessionID s)
        {
            Console.WriteLine(m.ToString());
        }
        public void OnMessage(QuickFix.FIX42.Reject m, SessionID s)
        {
            Console.WriteLine(m.ToString());
        }
        public void OnMessage(QuickFix.FIX42.SequenceReset m, SessionID s)
        {
            Console.WriteLine(m.ToString());
        }
        public void OnMessage(QuickFix.FIX42.Logon m, SessionID s)
        {
            Console.WriteLine(m.ToString());
        }
        public void OnMessage(QuickFix.FIX42.Logout m, SessionID s)
        {
            Console.WriteLine("Received Logout");
            if (m.IsSetField(QuickFix.Fields.Tags.NextExpectedMsgSeqNum))
            {
                int nextExpectedMsgSeqNum = m.GetInt(QuickFix.Fields.Tags.NextExpectedMsgSeqNum);
                if (MySession != null)
                {
                    MySession.NextSenderMsgSeqNum = nextExpectedMsgSeqNum;
                }
            }
        }
        public void OnMessage(QuickFix.FIX42.ExecutionReport m, SessionID s)
        {
            Console.WriteLine("Received execution report");
        }

        public void OnMessage(QuickFix.FIX42.OrderCancelReject m, SessionID s)
        {
            Console.WriteLine("Received order cancel reject");
        }

        public void OnMessage(QuickFix.FIX42.QuoteAcknowledgement m, SessionID s)
        {
            Console.WriteLine(m.ToString());
        }
        #endregion
    }
}
