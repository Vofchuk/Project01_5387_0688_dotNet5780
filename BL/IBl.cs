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
        bool IsAvailableGuestRequest(GuestRequest guestRequest);
        void OrderClosed(Order order);
        void CalculateCommision(Order order);
        void MarkDates(Order order);
        void UpadateUserStatus(Order order);
        bool DeleteableHostingUnit(HostingUnit hostingUnit);
        bool DisableCollectionClearence(Host host);
        void SendEmail(GuestRequest guestRequest);

        List<HostingUnit> CheckForAvailableHostingUnit(DateTime  date, int days);
        int PassedDays(DateTime first, DateTime second = default(DateTime));
        List<Order> OrdersCreated(int days);
        List<GuestRequest> MatchingRequirment(Func<GuestRequest, bool> predicate);
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
        int NumberOfOrders(HostingUnit hostingUnit, bool flag );

        List<GuestRequest> GuestRequestGroupedBySpecificArea(Location location);
        List<GuestRequest> GroupedByNumberOfGuests(int number);
        List<Host> GroupedByNumberOfHostingUnit( int  number);
        List<HostingUnit> HostingUnitGroupedBySpecificArea(Location location);








    }
}
