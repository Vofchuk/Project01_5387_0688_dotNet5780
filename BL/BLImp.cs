using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using DO;



namespace BL
{
    sealed class  BLImp : IBl
    {
        static readonly BLImp instance = new BLImp();
        static BLImp() { }
        BLImp() { }
        public static BLImp Instance { get { return instance; } }

        readonly DalApi.IDal dal = DalApi.DalFactory.GetDal();


        public int CalculateCommision(Order order)//
        {
            GuestRequest guestRequest = dal.RecieveGuesetRequest(order.GuestRequestKey);
            int commision = dal.GetCommissionRate() * PassedDays(guestRequest.EntryDate, guestRequest.ReleaseDate);
            order.Commission = commision;
            dal.UpdateOrder(order);
            Host host = dal.RecieveHost(order.HostID);
            host.TotalCommission += commision;
            dal.UpdateHost(host);
            return commision;
        }

        public bool CheckDate(GuestRequest guestRequest)//
        {
            return guestRequest.ReleaseDate > guestRequest.EntryDate;
        }

        public IEnumerable<HostingUnit> CheckForAvailableHostingUnit(DateTime date, int days)//
        {
            DateTime end = date.AddDays(days);
            GuestRequest temp = new GuestRequest() { EntryDate = date, ReleaseDate = end };

            var hostingUnit = from item in dal.hostingUnitsList(x => true)
                              where IsAvailableGuestRequest(temp, item)
                              select item;
            return hostingUnit;
        }
        public bool IsOpenOrder(Order order)//
        {

            return order.Status != Order_Status.CLIENT_CLOSED && order.Status != Order_Status.IGNORED_CLOSED && order.Status != Order_Status.IRRELEVANT;

        }
        /// <summary>
        ///  in this function we take all the orders that connected in to this hosting unit
        ///  and  check if  there any open order to this hosting unit  
        /// </summary>
        /// <param name="hostingUnit"></param>
        /// <returns></returns>
        public bool DeleteableHostingUnit(HostingUnit hostingUnit)//
        {
            var orders = from item in dal.ordersList(x => x.HostingUnitKey == hostingUnit.Key)
                         where IsOpenOrder(item)
                         select item;
            return !orders.Any();//check if there is somthing in the orders
        }
        public void CloseIrrelevantOrders(Order order)//
        {
            var orders = from item in dal.ordersList(x => x.Key != order.Key)
                         where item.GuestRequestKey == order.GuestRequestKey ||
                         item.HostingUnitKey == order.HostingUnitKey && !IsAvailableGuestRequest(dal.RecieveGuesetRequest(item.Key), dal.RecieveHostingUnit(item.HostingUnitKey))
                         select item;
            foreach (var item in orders)
            {
                if (AbleToChangeOrderStatus(item))
                {
                    item.Status = Order_Status.IRRELEVANT;
                    dal.UpdateOrder(item);
                }
            }
        }
        public bool AbleToChangeCollectionClearance(Host host)//
        {
            var orders = dal.ordersList(x => x.HostID == host.HostID).Where(x => IsOpenOrder(x));
            return orders.Count() == 0;
        }


        public bool EmailPremissionCheck(Host host)//
        {
            return host.CollectionClearance;
        }

        public List<GuestRequest> GroupedByNumberOfGuests(int number)
        {
            throw new NotImplementedException();
        }

        public List<Host> GroupedByNumberOfHostingUnit(int number)
        {
            throw new NotImplementedException();
        }

        public List<GuestRequest> GuestRequestGroupedBySpecificArea(Location location)
        {
            throw new NotImplementedException();
        }

        public List<HostingUnit> HostingUnitGroupedBySpecificArea(Location location)
        {
            throw new NotImplementedException();
        }

        public bool IsAvailableGuestRequest(GuestRequest guestRequest, HostingUnit hostingUnit)//
        {
            DateTime temp = guestRequest.EntryDate;
            while (temp != guestRequest.ReleaseDate)
            {
                if (hostingUnit[temp] == true)
                    return false;
                temp = temp.AddDays(1);
            }
            return true;
        }

        public void MarkDates(Order order)//
        {
            GuestRequest guestRequest = dal.RecieveGuesetRequest(order.GuestRequestKey);
            HostingUnit hostingUnit = dal.RecieveHostingUnit(order.HostingUnitKey);
            DateTime temp = guestRequest.EntryDate;
            //now we mark this days in true 
            while (DateTime.Compare(temp.AddDays(1), guestRequest.ReleaseDate) != 0)
            {
                hostingUnit[temp] = true;
                temp = temp.AddDays(1);
            }
            guestRequest.Status = Request_Statut.ORDERED;
            dal.UpdateGusetRequestStatus(guestRequest);
            CloseIrrelevantOrders(order);
        }

        public IEnumerable<GuestRequest> MatchingRequirment(Func<GuestRequest, bool> predicate)
        {
            var guestRequest = dal.GuestRequestsList().Where(predicate);
            return guestRequest;
        }//

        public int NumberOfInvitationsSent(GuestRequest guestRequest)//
        {
            return (dal.ordersList(x => x.GuestRequestKey == guestRequest.GuestRequestKey)).Count();
        }

        public int NumberOfSentOrders(HostingUnit hostingUnit)//
        {
           return dal.ordersList(x=> x.HostingUnitKey==hostingUnit.Key).Count();
        }

        public bool AbleToChangeOrderStatus(Order order)//
        {
            return order.Status != Order_Status.APPROVED;
        }

        public IEnumerable<Order> OrdersCreated(int days)//
        {
            return dal.ordersList(x => PassedDays(x.OrderDate) >= days);
        }

        public int PassedDays(DateTime first, DateTime second = default)//
        { 
            if (second == default(DateTime))
            {
                second = DateTime.Now;
            }
            return (second - first).Days;
        }

        public void SendEmail(GuestRequest guestRequest)
        {
            Console.WriteLine( guestRequest.ToString()+ "  send mail") ;
        }

        public void UpadateUserStatus(Order order)
        {
            var guestRequest = dal.RecieveGuesetRequest(order.Key);
            guestRequest.Status = Request_Statut.ORDERED;
            dal.UpdateGusetRequest(guestRequest);
            var orders = dal.ordersList(x => x.GuestRequestKey == order.GuestRequestKey&&x.Key!=order.Key);
            foreach (var item in orders)
            {
                if (AbleToChangeOrderStatus(item))
                {
                    item.Status = Order_Status.IRRELEVANT;
                }
            }
            
        }
        
    }
}
