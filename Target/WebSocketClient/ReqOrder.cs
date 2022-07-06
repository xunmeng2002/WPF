using System;
using System.Collections.Generic;
using System.Text;

namespace WebSocketClient
{
    public class ReqOrder : PropertyChangedNotify
    {
        private string Type = "";
        private string Customer = "";
        private int AcctType = 0;
        private int BsType = 0;

        private string Investid = "";
        private int IsCancel = 0;

        private int Market = 0;
        private string SecurityId = "";
        private int OrdPrice = 0;
        private int OrdQty = 0;
        private int OrdType = 0;


        public string type
        {
            get => Type;
            set
            {
                if (Type == value)
                    return;
                Type = value;
                OnPropertyChanged();
            }
        }
        public string customer
        {
            get => Customer;
            set
            {
                if (Customer == value)
                    return;
                Customer = value;
                OnPropertyChanged();
            }
        }
        public int acctType
        {
            get => AcctType;
            set
            {
                if (AcctType == value)
                    return;
                AcctType = value;
                OnPropertyChanged();
            }
        }
        public int bsType
        {
            get => BsType;
            set
            {
                if (BsType == value)
                    return;
                BsType = value;
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
        public int isCancel
        {
            get => IsCancel;
            set
            {
                if (IsCancel == value)
                    return;
                IsCancel = value;
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
        public int ordType
        {
            get => OrdType;
            set
            {
                if (OrdType == value)
                    return;
                OrdType = value;
                OnPropertyChanged();
            }
        }
    }
}
