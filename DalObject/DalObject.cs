using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;

namespace DalObject
{
    public class DalObject <T> : IDal<T>
    {
        public bool Add(T t)
        {
            throw new NotImplementedException();
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
