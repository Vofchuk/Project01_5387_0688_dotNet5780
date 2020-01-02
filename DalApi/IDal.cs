using DO;
using System;
using System.Collections.Generic;

namespace DalApi
{
    public interface IDal
    {
        HostingUnit RecieveHostingUnit(int key);
        int AddHostingUnit(HostingUnit hostingUnit);
        void UpdateHostingUnit(HostingUnit hostingUnit);
        void DeleteHostingUnit(HostingUnit hostingUnit);
        Person RecievePerson(int key);
        bool AddPerson(Person person);
        bool DeletePerson(Person person);
        GuestRequest RecieveGuesetRequest(int key);
        int AddGuesetRequest(GuestRequest request);
        void UpdateGusetRequest(GuestRequest request);
       void UpdateGusetRequestStatus(GuestRequest request);
        Host RecieveHost(int key);
        bool AddHost(Host host);
        void DeleteHost(Host host);
        void UpdateHost(Host host);
        Order RecieveOrder(int key);
        int AddOrder(Order order);
        void UpdateOrder(Order order);
        List<HostingUnit> hostingUnitsList(Func<HostingUnit, bool> predicate);
        List<GuestRequest> GuestRequestsList();
        List<Order> ordersList(Func<Order, bool> predicate);
        IEnumerable<BankBranch> GetBankBranchesList();
        int GetCommission(); 
        //bool Recieve(T t);
        //bool Add(T t);
        //bool Update(T t);
        //bool StatusUpdate(T t);
        //bool Delete(T t);
        //bool RecieveList(T t, Predicate<bool> predicate);
    }
}
