﻿using DO;
using System;
using System.Collections.Generic;

namespace DalApi
{
    public interface IDal
    {
        Person RecievePerson(Person person);
        bool AddPerson(Person person);
        bool DeletePerson(Person person);
        GuestRequest RecieveGuset(GuestRequest request);
        bool AddGuset(GuestRequest request);
        bool UpdateGuset(GuestRequest request);
        bool GusetRequestStatus(GuestRequest request);
        Host RecieveHost(Host host);
        bool AddHosst(Host host);
        bool DeleteHost(Host host);
        bool UpdateHost(Host host);
        Order RecieveOrder(Order order);
        bool AddOrder(Order order);
        bool UpdateOrder(Order order);
        List<HostingUnit> hostingUnitsList(Predicate<bool> predicate);
        List<GuestRequest> guestRequestsList();
        List<Order> ordersList(Predicate<bool> predicate);
        //bool Recieve(T t);
        //bool Add(T t);
        //bool Update(T t);
        //bool StatusUpdate(T t);
        //bool Delete(T t);
        //bool RecieveList(T t, Predicate<bool> predicate);
    }
}
