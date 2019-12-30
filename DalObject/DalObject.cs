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
    sealed class DalObject : IDal
    {
        static readonly DalObject instance = new DalObject();
        static DalObject() { }
        DalObject() { }
        public static DalObject Instance { get { return instance; } }
        bool IDal.AddHost(Host host)
        {
            bool exist = DataSource.hosts.Any(x => host.Id == x.Id);
            if (!exist)
                // throw new DuplicateIdException("GuestRequest", request.GuestRequestKey);
                DataSource.hosts.Add(host.Clone());
            return exist;
        }//

        bool IDal.AddPerson(Person person)
        {
            if (!(Check(from item in DataSource.persons
                      where item.Id == person.Id
                      select item),person.Id))
                // throw new DuplicateIdException("GuestRequest", request.GuestRequestKey);
                DataSource.persons.Add(person.Clone());
            return exist;
        }
        int IDal.AddGusetRequest(GuestRequest request)//
        {
            bool exist = DataSource.guestRequests.Any(x => request.GuestRequestKey == x.GuestRequestKey);
            if (!exist)
                // throw new DuplicateIdException("GuestRequest", request.GuestRequestKey);
                DataSource.guestRequests.Add(request.Clone());
            return request.GuestRequestKey;
        }//
        int IDal.AddHostingUnit(HostingUnit hostingUnit)//
        {
            bool exist = DataSource.hostingUnits.Any(x => hostingUnit.Key == x.Key);
            if (!exist)
                // throw new DuplicateIdException("GuestRequest", request.GuestRequestKey);
                DataSource.hostingUnits.Add(hostingUnit.Clone());
            return hostingUnit.Key;
        }

        int IDal.AddOrder(Order order)//
        {
            bool exist = DataSource.orders.Any(x => order.Key == x.Key);
            if (!exist)
                // throw new DuplicateIdException("GuestRequest", request.GuestRequestKey);
                DataSource.orders.Add(order.Clone());
            return order.GuestRequestKey;
        }
        void IDal.DeleteHost(Host host)//
        {
            int count = DataSource.hosts.RemoveAll(x => host.Id == x.Id);
            if (count == 0)
               throw new MissingIdException("Host",host.Id);
            host.Status = Status.INACTIVE;
            DataSource.hosts.Add(host.Clone());
        }

        void IDal.DeleteHostingUnit(HostingUnit hostingUnit)//
        {
            int count = DataSource.hostingUnits.RemoveAll(x => hostingUnit.Key == x.Key);
            if (count == 0)
                throw new MissingIdException("hostingUnit", hostingUnit.Key);
            hostingUnit.Status = Status.INACTIVE;
            DataSource.hostingUnits.Add(hostingUnit.Clone());
        }

        bool IDal.DeletePerson(Person person)//
        {
            int count = DataSource.persons.RemoveAll(x => person.Id == x.Id);
            if (count == 0)
                throw new MissingIdException("Person", person.Id);
            return true;
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

        GuestRequest IDal.RecieveGusetRequest(GuestRequest request)
        {
            throw new NotImplementedException();
        }

        Host IDal.RecieveHost(Host host)
        {
            throw new NotImplementedException();
        }

        HostingUnit IDal.RecieveHostingUnit(HostingUnit hostingUnit)
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

        bool IDal.UpdateGusetRequest(GuestRequest request)
        {
            throw new NotImplementedException();
        }

        bool IDal.UpdateHost(Host host)
        {
            throw new NotImplementedException();
        }

        bool IDal.UpdateHostingUnit(HostingUnit hostingUnit)
        {
            throw new NotImplementedException();
        }

        bool IDal.UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
    bool check (object obj)
    {
        Type n = typeof(DataSource);
        PropertyInfo[] propertyInfos = n.GetProperties(BindingFlags.Public | BindingFlags.Static);
        
        from
        {

        }

    }
}
