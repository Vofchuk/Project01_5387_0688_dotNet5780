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
    public class DalObject <T> : IDal<T>
    {
        public bool Add(T t)
        {
            T temp = t.Clone(); 
            switch (temp.GetType().Name)
            {
                case "Person":
                    {
                        Person p = temp as Person;
                        DataSource.persons.Add(p);
                        break;
                    }
                case "Host":
                    {
                        Host h = temp as Host;
                        DataSource.hosts.Add(h);
                        break;
                    }
                case "Order":
                    {
                        Person p = temp as Person;
                        DataSource.persons.Add(p);
                        break;
                    }
            }
            return true;
        }

        public bool Delete(T t)
        {
            throw new NotImplementedException();
        }

        public bool Recieve(T t)
        {
            throw new NotImplementedException();
        }

        public bool RecieveList(T t, Predicate<bool> predicate)
        {
            throw new NotImplementedException();
        }

        public bool StatusUpdate(T t)
        {
            throw new NotImplementedException();
        }

        public bool Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
