using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    class Person
    {
        public int Id { get; private set; }
        public ID IdType { get; private set; }
        public Person_Status Status { get; private set; }
        public int Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int PhoneNumber { get; private set; }
        public string MailAddress { get; private set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
