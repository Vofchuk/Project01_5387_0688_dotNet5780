using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using DO;



namespace BL
{
    class BLImp : IBl
    {
        readonly DalApi.IDal dal = DalApi.DalFactory.GetDal();
        public int CalculateCommision(Order order)
        {
            GuestRequest guestRequest = dal.RecieveGuesetRequest(order.GuestRequestKey);
            return dal.GetCommission()*PassedDays(guestRequest.EntryDate, guestRequest.ReleaseDate);
        }

        public bool CheckDate(GuestRequest guestRequest)
        {
            return guestRequest.ReleaseDate>guestRequest.EntryDate;
        }

        public List<HostingUnit> CheckForAvailableHostingUnit(DateTime date, int days)
        {
            throw new NotImplementedException();
        }

        public bool DeleteableHostingUnit(HostingUnit hostingUnit)
        {
            throw new NotImplementedException();
        }

        public bool DisableCollectionClearence(Host host)
        {
            var list = from GuestRequest in dal.GuestRequestsList()
                       let GuestRequestKey = GuestRequest.GuestRequestKey
                       from key in dal.RecieveHost(host.Id).GuestRequestsKeys
                       where key==GuestRequestKey
                       select new { Status=GuestRequest.Status };
            foreach(var item in list)
            {
                if (item.Status == Request_Statut.OPEN)
                    return false;
            }
            return true;
        }

        public bool EmailPremissionCheck(Host host)
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

        public bool IsAvailableGuestRequest(GuestRequest guestRequest)
        {
            throw new NotImplementedException();
        }

        public void MarkDates(Order order)
        {
            GuestRequest guestRequest = dal.RecieveGuesetRequest(order.GuestRequestKey);
            HostingUnit hostingUnit = dal.RecieveHostingUnit(order.HostingUnitKey);
            DateTime  temp = guestRequest.EntryDate;
            //now we mark this days in true 
            while (DateTime.Compare(temp.AddDays(1), guestRequest.ReleaseDate) != 0)
            {
                hostingUnit[temp] = true;
                temp = temp.AddDays(1);
            }
        }

        public List<GuestRequest> MatchingRequirment(Func<GuestRequest, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public int NumberOfInvitationsSent(GuestRequest guestRequest)
        {
            throw new NotImplementedException();
        }

        public int NumberOfOrders(HostingUnit hostingUnit, bool flag)
        {

            throw new NotImplementedException();
        }

        public void OrderClosed(Order order)
        {
            throw new NotImplementedException();
        }

        public List<Order> OrdersCreated(int days)
        {
            throw new NotImplementedException();
        }

        public int PassedDays(DateTime first, DateTime second = default)
        {
           
            int count = 0;
            if (second == default(DateTime))
            {
                second = DateTime.Now;
            }
            for (int i = 1; first.AddDays(i) <= second; ++i)
                count++;
            return count;
               
        }

        public void SendEmail(GuestRequest guestRequest)
        {
            throw new NotImplementedException();
        }

        public void UpadateUserStatus(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
