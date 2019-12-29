using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DS;
using DO;
using System.Reflection;

namespace DalObject
{
    public class DalObject : IDal
    {
        bool IDal.AddGuset(GuestRequest request)
        {
            throw new NotImplementedException();
        }

        bool IDal.AddHosst(Host host)
        {
            throw new NotImplementedException();
        }

        bool IDal.AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        bool IDal.AddPerson(Person person)
        {
            throw new NotImplementedException();
        }

        bool IDal.DeleteHost(Host host)
        {
            throw new NotImplementedException();
        }

        bool IDal.DeletePerson(Person person)
        {
            throw new NotImplementedException();
        }

        List<GuestRequest> IDal.guestRequestsList()
        {
            throw new NotImplementedException();
        }
        bool IDal.GusetRequestStatus(GuestRequest request)
        {
            throw new NotImplementedException();
        }

        List<HostingUnit> IDal.hostingUnitsList(Predicate<bool> predicate)
        {
            throw new NotImplementedException();
        }

        List<Order> IDal.ordersList(Predicate<bool> predicate)
        {
            throw new NotImplementedException();
        }

        GuestRequest IDal.RecieveGuset(GuestRequest request)
        {
            throw new NotImplementedException();
        }

        Host IDal.RecieveHost(Host host)
        {
            throw new NotImplementedException();
        }

        Order IDal.RecieveOrder(Order order)
        {
            throw new NotImplementedException();
        }

        Person IDal.RecievePerson(Person person)
        {
            throw new NotImplementedException();
        }

        bool IDal.UpdateGuset(GuestRequest request)
        {
            throw new NotImplementedException();
        }

        bool IDal.UpdateHost(Host host)
        {
            throw new NotImplementedException();
        }

        bool IDal.UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

    }
}
