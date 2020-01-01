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
        
    }
}
