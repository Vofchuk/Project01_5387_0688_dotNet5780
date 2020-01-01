using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class HostingUnit
    {
        public int Key { get; set; }

        public int Owner { get; set; }

        public string HostingUnitName { get; set; }

        public bool[,] Diary { get; set; }
        public Status Status { get; set; }
        public bool this[DateTime date]
        {
            get
            {
                return Diary[date.Month - 1, date.Day - 1];
            }
            set
            {
                Diary[date.Month - 1, date.Day - 1] = value;
            }
        }

        public override string ToString()

        {
            return base.ToString();
        }
    }
}
