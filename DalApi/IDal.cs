using DO;
using System;
using System.Collections.Generic;

namespace DalApi
{
    public interface IDal
    {
        HostingUnit RecieveHostingUnit(int key);
        int AddHostingUnit(HostingUnit hostingUnit);
        bool UpdateHostingUnit(HostingUnit hostingUnit);
        void DeleteHostingUnit(HostingUnit hostingUnit);
        Person RecievePerson(int key);
        bool AddPerson(Person person);
        bool DeletePerson(Person person);
        GuestRequest RecieveGusetRequest(int key);
        int AddGusetRequest(GuestRequest request);
        bool UpdateGusetRequest(GuestRequest request);
        bool GusetRequestStatus(GuestRequest request);
        Host RecieveHost(int key);
        bool AddHost(Host host);
        void DeleteHost(Host host);
        bool UpdateHost(Host host);
        Order RecieveOrder(int key);
        int AddOrder(Order order);
        bool UpdateOrder(Order order);
        List<HostingUnit> hostingUnitsList(Func<HostingUnit, bool> predicate);
        List<GuestRequest> guestRequestsList();
        List<Order> ordersList(Func<Order, bool> predicate);
        //bool Recieve(T t);
        //bool Add(T t);
        //bool Update(T t);
        //bool StatusUpdate(T t);
        //bool Delete(T t);
        //bool RecieveList(T t, Predicate<bool> predicate);
    }
}
