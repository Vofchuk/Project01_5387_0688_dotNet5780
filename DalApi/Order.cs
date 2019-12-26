using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    class Order
    {
        public int Key { get; private set; }
        public int HostingUnitKey { get; private set; }
        public int GuestRequestKey { get; private set; }
        public Order_Status Status { get; private set; }
        public DateTime OrderDate { get; private set; }
        public DateTime SentDate { get; private set; }
        public DateTime CloseDate { get; private set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
