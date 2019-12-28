using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DalApi
{
    interface IDal<T>
    {
        //bool RecievePerson(Person person);
        //bool AddPerson(Person person);
        //bool DeletePerson(Person person);
        //bool RecieveGuset(GuestRequest request);
        //bool AddGuset(GuestRequest request);
        //bool UpdateGuset(GuestRequest request);
        //bool GusetRequestStatus(GuestRequest request);
        //bool Host(Host host);
        //bool AddGuset(GuestRequest request);
        //bool UpdateGuset(GuestRequest request);
        //bool GusetRequestStatus(GuestRequest request);
        bool Recieve(T t);
        bool Add(T t);
        bool Update(T t);
        bool StatusUpdate(T t);
        bool Delete(T t);
        bool RecieveList(T t, Predicate<bool> predicate);
    }
}
