using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferCommonLibrary.Mdb
{
    public interface IMdbSubscribe
    {
        public void ReqInsertOrder(Order order);
        public void ReqInsertOrderCancel(OrderCancel orderCancel);
    }
}
