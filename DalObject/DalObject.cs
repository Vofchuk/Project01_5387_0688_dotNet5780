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
        public bool AddHost(Host host)//
        {
            bool exist = DataSource.hosts.Any(x => host.HostID == x.HostID);
            if (exist)
                throw new DuplicateIdException("Host", host.HostID);
            Configuration.TotalHosts++;
            DataSource.hosts.Add(host.Clone());
            return exist;
        }//
        public bool AddPerson(Person person)//
        {
            bool exist = DataSource.persons.Any(x => x.Id == person.Id);
            if (exist)
                throw new DuplicateIdException("Person", person.Id);
            Configuration.TotalPersons++;
            DataSource.persons.Add(person.Clone());
            return exist;
        }
        public int AddGuesetRequest(GuestRequest request)// 
        {
            bool exist = DataSource.guestRequests.Any(x => request.GuestRequestKey == x.GuestRequestKey);
            if (exist)
                throw new DuplicateIdException("GuestRequest", request.GuestRequestKey);
            request.GuestRequestKey = Configuration.GuestRequestKey++;
            Configuration.TotalGuestRequest++;
            DataSource.guestRequests.Add(request.Clone());
            return request.GuestRequestKey;
        }//
        public int AddHostingUnit(HostingUnit hostingUnit)//
        {
            bool exist = DataSource.hostingUnits.Any(x => hostingUnit.Key == x.Key);
            if (exist)
                throw new DuplicateIdException("HostingUnit", hostingUnit.Key);
            hostingUnit.Key = Configuration.HostingUnitKey++;
            Configuration.TotalHostingUnit++;
            DataSource.hostingUnits.Add(hostingUnit.Clone());
            return hostingUnit.Key;
        }
        public int AddOrder(Order order)//
        {
            bool exist = DataSource.orders.Any(x => order.Key == x.Key);
            if (exist)
                throw new DuplicateIdException("Order", order.Key);
            order.Key = Configuration.OrderKey++;
            Configuration.TotalOrders++;
            DataSource.orders.Add(order.Clone());
            return order.Key;
        }
        public void DeleteHost(Host host)//
        {
            int count = DataSource.hosts.RemoveAll(x => host.HostID == x.HostID);
            if (count == 0)
                throw new MissingIdException("Host", host.HostID);
            host.Status = Status.INACTIVE;
            DataSource.hosts.Add(host.Clone());
        }
        public void DeleteHostingUnit(HostingUnit hostingUnit)//
        {
            int count = DataSource.hostingUnits.RemoveAll(x => hostingUnit.Key == x.Key);
            if (count == 0)
                throw new MissingIdException("hostingUnit", hostingUnit.Key);
            hostingUnit.Status = Status.INACTIVE;
            DataSource.hostingUnits.Add(hostingUnit.Clone());
        }
        public bool DeletePerson(Person person)//
        {
            int count = DataSource.persons.RemoveAll(x => person.Id == x.Id);
            if (count == 0)
                throw new MissingIdException("Person", person.Id);
            Configuration.TotalPersons -= count;
            return true;
        }
        public void UpdateGusetRequestStatus(GuestRequest request)//
        {
            UpdateGusetRequest(request);
        }
        public IEnumerable<GuestRequest> GuestRequestsList()//
        {
            var temp = from item in DataSource.guestRequests
                       select item.Clone();
            return temp;
        }
        public IEnumerable<HostingUnit> hostingUnitsList(Func<HostingUnit, bool> predicate)//
        {
            return DataSource.hostingUnits.Where(predicate).Select(HU => HU.Clone());
        }
        public IEnumerable<Order> ordersList(Func<Order, bool> predicate)//
        {
            return DataSource.orders.Where(predicate).Select(o => o.Clone());
        }

        public GuestRequest RecieveGuesetRequest(int key)//
        {
            GuestRequest GR = DataSource.guestRequests.FirstOrDefault(x => x.GuestRequestKey == key);
            return GR == null ? throw new MissingIdException("GuestRequest", key) : GR.Clone();
        }

        public Host RecieveHost(int key)//
        {
            Host h = DataSource.hosts.FirstOrDefault(x => x.HostID == key);
            return h == null ? throw new MissingIdException("Host", key) : h.Clone();
        }

        public HostingUnit RecieveHostingUnit(int key)//
        {
            HostingUnit HU = DataSource.hostingUnits.FirstOrDefault(x => x.Key == key);
            return HU == null ? throw new MissingIdException("HostingUnit", key) : HU.Clone();
        }

        public Order RecieveOrder(int key)//
        {
            Order o = DataSource.orders.FirstOrDefault(x => x.Key == key);
            return o == null ? throw new MissingIdException("Order", key) : o.Clone();
        }

        public Person RecievePerson(int id)//
        {
            Person p = DataSource.persons.FirstOrDefault(x => x.Id == id);
            return p == null ? throw new MissingIdException("Order", id) : p.Clone();
        }

        public void UpdateGusetRequest(GuestRequest request)
        {

            bool exist = DataSource.orders.Any(x => x.GuestRequestKey == request.GuestRequestKey);
            if (exist)
                throw new MissingIdException("GuestRequest", request.GuestRequestKey);
            DataSource.guestRequests.RemoveAll(x => x.GuestRequestKey == request.GuestRequestKey);
            DataSource.guestRequests.Add(request.Clone());
        }

        public void UpdateHost(Host host)
        {
            int count = DataSource.hosts.RemoveAll(x => x.HostID == host.HostID);
            if (count == 0)
                throw new MissingIdException("Host", host.HostID);
            DataSource.hosts.Add(host.Clone());
        }

        public void UpdateHostingUnit(HostingUnit hostingUnit)
        {
            int count = DataSource.hostingUnits.RemoveAll(x => x.Key == hostingUnit.Key);
            if (count == 0)
                throw new MissingIdException("HostingUnit", hostingUnit.Key);
            DataSource.hostingUnits.Add(hostingUnit.Clone());
        }
        public void UpdateOrder(Order order)
        {
            int count = DataSource.orders.RemoveAll(x => x.Key == order.Key);
            if (count == 0)
                throw new MissingIdException("Host", order.Key);
            DataSource.orders.Add(order.Clone());
        }
        public IEnumerable<BankBranch> GetBankBranchesList()
        {
            var list = from item in DataSource.bankBranches
                       select item.Clone();
            return list;
        }
        public int GetCommissionRate()
        {
            return Configuration.Commission;
        }
        public int GetCommission(Order order)
        {
            var temp = DataSource.orders.FirstOrDefault(x => x.Key == order.Key);
            return temp == null ? throw new MissingIdException("Order", order.Key) : temp.Commission;

        }
    }
}
