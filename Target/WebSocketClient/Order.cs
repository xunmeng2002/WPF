using System;
using System.Collections.Generic;
using System.Text;

namespace WebSocketClient
{
    
    public class Order : PropertyChangedNotify
    {
        private string Type = "";
        private int Reqid = 0;
        private int Envno = 0;
        private string CustomerId = "";
        private string Investid = "";
        private int Plotid = 0;
        private int LocalId = 0;
        private int Market = 0;
        private string SecurityId = "";
        private int OrdQty = 0;
        private int OrdPrice = 0;
        private int TradeQty = 0;
        private int TradeAvgPx = 0;
        private int SendLocTime = 0;
        private int CnfLocTime = 0;
        private int SendTime = 0;
        private int CnfTime = 0;
        private int ErrorId = 0;
        private string ErrorMsg = "";



        public string type {
            get => Type;
            set
            {
                if (Type == value)
                    return;
                Type = value;
                OnPropertyChanged();
            }
        }
        public int reqid
        {
            get => Reqid;
            set
            {
                if (Reqid == value)
                    return;
                Reqid = value;
                OnPropertyChanged();
            }
        }
        public int envno
        {
            get => Envno;
            set
            {
                if (Envno == value)
                    return;
                Envno = value;
                OnPropertyChanged();
            }
        }
        public string customerId
        {
            get => CustomerId;
            set
            {
                if (CustomerId == value)
                    return;
                CustomerId = value;
                OnPropertyChanged();
            }
        }
        public string investid
        {
            get => Investid;
            set
            {
                if (Investid == value)
                    return;
                Investid = value;
                OnPropertyChanged();
            }
        }
        public int plotid
        {
            get => Plotid;
            set
            {
                if (Plotid == value)
                    return;
                Plotid = value;
                OnPropertyChanged();
            }
        }
        public int localId
        {
            get => LocalId;
            set
            {
                if (LocalId == value)
                    return;
                LocalId = value;
                OnPropertyChanged();
            }
        }
        public int market
        {
            get => Market;
            set
            {
                if (Market == value)
                    return;
                Market = value;
                OnPropertyChanged();
            }
        }
        public string securityId
        {
            get => SecurityId;
            set
            {
                if (SecurityId == value)
                    return;
                SecurityId = value;
                OnPropertyChanged();
            }
        }
        public int ordQty
        {
            get => OrdQty;
            set
            {
                if (OrdQty == value)
                    return;
                OrdQty = value;
                OnPropertyChanged();
            }
        }
        public int ordPrice
        {
            get => OrdPrice;
            set
            {
                if (OrdPrice == value)
                    return;
                OrdPrice = value;
                OnPropertyChanged();
            }
        }
        public int tradeQty
        {
            get => TradeQty;
            set
            {
                if (TradeQty == value)
                    return;
                TradeQty = value;
                OnPropertyChanged();
            }
        }
        public int tradeAvgPx
        {
            get => TradeAvgPx;
            set
            {
                if (TradeAvgPx == value)
                    return;
                TradeAvgPx = value;
                OnPropertyChanged();
            }
        }
        public int sendLocTime
        {
            get => SendLocTime;
            set
            {
                if (SendLocTime == value)
                    return;
                SendLocTime = value;
                OnPropertyChanged();
            }
        }
        public int cnfLocTime
        {
            get => CnfLocTime;
            set
            {
                if (CnfLocTime == value)
                    return;
                CnfLocTime = value;
                OnPropertyChanged();
            }
        }
        public int sendTime
        {
            get => SendTime;
            set
            {
                if (SendTime == value)
                    return;
                SendTime = value;
                OnPropertyChanged();
            }
        }
        public int cnfTime
        {
            get => CnfTime;
            set
            {
                if (CnfTime == value)
                    return;
                CnfTime = value;
                OnPropertyChanged();
            }
        }
        public int errorId
        {
            get => ErrorId;
            set
            {
                if (ErrorId == value)
                    return;
                ErrorId = value;
                OnPropertyChanged();
            }
        }
        public string errorMsg
        {
            get => ErrorMsg;
            set
            {
                if (ErrorMsg == value)
                    return;
                ErrorMsg = value;
                OnPropertyChanged();
            }
        }

    }
}
