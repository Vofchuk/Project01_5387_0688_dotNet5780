﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalObject
{
     static class Configuration
     {
          public static int HostingUnitKey = 10000000;
          public static int GuestRequestKey = 20000000;
          public static int OrderKey = 30000000;
          public static int TotalHostingUnit = 0;
          public static int TotalGuestRequest = 0;
          public static int TotalHosts = 0;
          public static int TotalPersons = 0;// maybe
          public static int TotalOrders = 0;

     }
}
//added counter to all classes , necessary to get summary to the maneger
