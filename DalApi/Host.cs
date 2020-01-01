
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class Host
    {
        public int Id { get; set; }
        public int BranchNumber { get; set; }
        public int BankNumber { get; set; }
        public int BankAccuontNumber { get; set; }
        public bool CollectionClearance { get; set; }
        public Status Status { get; set; }
        public List<int> MyRequests { get; private set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
