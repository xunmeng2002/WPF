using Microsoft.Extensions.Logging;
using OfferCommon.Mdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCommon
{
    public interface IMdbInterface
    {
        public void OnConnected();
        public void OnDisconnected();
        public void OnLogin();
        public void OnLogout();
        public void OnRtnOrder(Order order);
        public void OnRtnTrade(Trade trade);
        public void OnErrRtnOrderCancel(OrderCancel orderCancel);
    }
}
