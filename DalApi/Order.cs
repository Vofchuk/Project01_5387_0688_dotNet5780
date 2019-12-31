using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class Order
    {
        public int Key { get;  set; }
        public int HostingUnitKey { get;  set; }
        public int GuestRequestKey { get;  set; }
        public Order_Status Status { get;  set; }
        public DateTime OrderDate { get;  set; }
        public DateTime SentDate { get;  set; }
        public DateTime CloseDate { get;  set; }
        
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
