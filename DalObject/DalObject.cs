using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DS;
using DO;
using System.Reflection;

namespace Dal
{
    sealed class DalObject : IDal
    {
        static readonly DalObject instance = new DalObject();
        static DalObject() { }
        DalObject() { }
        public static DalObject Instance { get { return instance; } }
        bool IDal.AddHost(Host host)//
        {
            bool exist = DataSource.hosts.Any(x => host.Id == x.Id);
            if (exist)
                throw new DuplicateIdException("Host", host.Id);
            Configuration.TotalHosts++;
            DataSource.hosts.Add(host.Clone());
            return exist;
        }//

        bool IDal.AddPerson(Person person)//
        {
            bool exist = DataSource.persons.Any(x => x.Id == person.Id);
            if (exist)
                throw new DuplicateIdException("Person", person.Id);
            Configuration.TotalPersons++;
            DataSource.persons.Add(person.Clone());
            return exist;
        }
        int IDal.AddGusetRequest(GuestRequest request)// 
        {
            bool exist = DataSource.guestRequests.Any(x => request.GuestRequestKey == x.GuestRequestKey);
            if (exist)
                throw new DuplicateIdException("GuestRequest", request.GuestRequestKey);
            request.GuestRequestKey = Configuration.GuestRequestKey++;
            Configuration.TotalGuestRequest++;
            DataSource.guestRequests.Add(request.Clone());
            return request.GuestRequestKey;
        }//
        int IDal.AddHostingUnit(HostingUnit hostingUnit)//
        {
            bool exist = DataSource.hostingUnits.Any(x => hostingUnit.Key == x.Key);
            if (exist)
                throw new DuplicateIdException("HostingUnit", hostingUnit.Key);
            hostingUnit.Key = Configuration.HostingUnitKey++;
            Configuration.TotalHostingUnit++;
            DataSource.hostingUnits.Add(hostingUnit.Clone());
            return hostingUnit.Key;
        }

        int IDal.AddOrder(Order order)//
        {
            bool exist = DataSource.orders.Any(x => order.Key == x.Key);
            if (exist)
                throw new DuplicateIdException("Order", order.Key);
            order.Key = Configuration.OrderKey++;
            Configuration.TotalOrders++;
            DataSource.orders.Add(order.Clone());
            return order.Key;
        }
        void IDal.DeleteHost(Host host)//
        {
            int count = DataSource.hosts.RemoveAll(x => host.Id == x.Id);
            if (count == 0)
                throw new MissingIdException("Host", host.Id);
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
            Configuration.TotalPersons -= count;
            return true;
        }

        void IDal.UpdateGusetRequestStatus(GuestRequest request)//
        {
          int count =  DataSource.guestRequests.RemoveAll(x => x.GuestRequestKey == request.GuestRequestKey);
            if (count == 0)
                throw new MissingIdException("GuestRequest", request.GuestRequestKey);
            DataSource.guestRequests.Add(request.Clone());
        }
        List<GuestRequest> IDal.guestRequestsList()//
        {
            var temp = from item in DataSource.guestRequests
                       select item.Clone();
            return temp.ToList();
        }
        List<HostingUnit> IDal.hostingUnitsList(Func<HostingUnit,bool> predicate)//
        {
            return DataSource.hostingUnits.Where(predicate).Select(HU=> (HostingUnit)HU.Clone()).ToList();
        }
        List<Order> IDal.ordersList(Func<Order, bool> predicate)//
        {
            return DataSource.orders.Where(predicate).Select(o => (Order)o.Clone()).ToList();
        }

        GuestRequest IDal.RecieveGuesetRequest(int key)//
        {
            GuestRequest GR = DataSource.guestRequests.FirstOrDefault(x => x.GuestRequestKey == key);
            return GR == null ? throw new MissingIdException("GuestRequest", key) : GR.Clone();
        }

        Host IDal.RecieveHost(int key)//
        {
            Host h = DataSource.hosts.FirstOrDefault(x => x.Id == key);
            return h == null ? throw new MissingIdException("Host", key) : h.Clone();
        }

        HostingUnit IDal.RecieveHostingUnit(int key)//
        {
            HostingUnit HU = DataSource.hostingUnits.FirstOrDefault(x => x.Key == key);
            return HU == null ? throw new MissingIdException("HostingUnit", key) : HU.Clone();
        }

        Order IDal.RecieveOrder(int key)//
        {
            Order o = DataSource.orders.FirstOrDefault(x => x.Key == key);
            return o == null ? throw new MissingIdException("Order", key) : o.Clone();
        }

        Person IDal.RecievePerson(int id)//
        {
            Person p = DataSource.persons.FirstOrDefault(x => x.Id == id);
            return p == null ? throw new MissingIdException("Order", id) : p.Clone();
        }

        void IDal.UpdateGusetRequest(GuestRequest request)
        {
        if (true)
            {
                int count = DataSource.guestRequests.RemoveAll(x => x.GuestRequestKey == request.GuestRequestKey);
                if (count == 0)
                    throw new MissingIdException("GuestRequest", request.GuestRequestKey);
                DataSource.guestRequests.Add(request.Clone());
            }
        }

       void IDal.UpdateHost(Host host)
        {
            int count = DataSource.hosts.RemoveAll(x => x.Id == host.Id);
            if (count == 0)
                throw new MissingIdException("Host", host.Id);
            DataSource.hosts.Add(host.Clone());
        }

        void IDal.UpdateHostingUnit(HostingUnit hostingUnit)
        {
            int count = DataSource.hostingUnits.RemoveAll(x => x.Key == hostingUnit.Key);
            if (count == 0)
                throw new MissingIdException("HostingUnit", hostingUnit.Key);
            DataSource.hostingUnits.Add(hostingUnit.Clone());
        }

        void IDal.UpdateOrder(Order order)
        {
            int count = DataSource.orders.RemoveAll(x => x.Key == order.Key);
            if (count == 0)
                throw new MissingIdException("Host", order.Key);
            DataSource.orders.Add(order.Clone());
        }
        List<BankBranch> IDal.GetBankBranchesList()
        {
            return DataSource.bankBranches.Clone();
            //var list = from item in DataSource.bankBranches
            //           select item.Clone();
            //return list.ToList();
        }

    }
}
