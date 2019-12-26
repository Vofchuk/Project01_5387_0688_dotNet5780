using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    class Host
    {
        public int Id { get; private set; }
        public int BranchNumber { get; private set; }
        public int BankNumber { get; private set; }
        public int BankAccuontNumber { get; private set; }
        public bool CollectionClearance { get; private set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
