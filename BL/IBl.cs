using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace BlApi
{
   public interface IBl
    {
        
        bool CheckDate(GuestRequest guestRequest);
        bool EmailPremissionCheck(Host host);
        //check that we dont have overlap
        bool IsAvailableGuestRequest(GuestRequest guestRequest, HostingUnit hostingUnit);
        bool AbleToChangeOrderStatus(Order order);
        int CalculateCommision(Order order);
        void MarkDates(Order order);
        void UpadateUserStatus(Order order);
        bool DeleteableHostingUnit(HostingUnit hostingUnit);
        bool AbleToChangeCollectionClearance(Host host);
        void SendEmail(GuestRequest guestRequest);
        IEnumerable<HostingUnit> CheckForAvailableHostingUnit(DateTime  date, int days);
        int PassedDays(DateTime first, DateTime second = default(DateTime));
        IEnumerable<Order> OrdersCreated(int days);
        IEnumerable<GuestRequest> MatchingRequirment(Func<GuestRequest, bool> predicate);
        int NumberOfInvitationsSent(GuestRequest guestRequest);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostingUnit"></param>
        /// <param name="flag">
        /// true for sent invitation 
        /// false for Closed invitaion 
        /// </param>
        /// <returns></returns>
        int NumberOfSentOrders(HostingUnit hostingUnit);
        void CloseIrrelevantOrders(Order order);
        List<GuestRequest> GuestRequestGroupedBySpecificArea(Location location);
        List<GuestRequest> GroupedByNumberOfGuests(int number);
        List<Host> GroupedByNumberOfHostingUnit( int  number);
        List<HostingUnit> HostingUnitGroupedBySpecificArea(Location location);

        bool IsOpenOrder(Order order);

    }
}
