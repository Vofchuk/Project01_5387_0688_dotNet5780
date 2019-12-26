using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    class GuestRequest
    {
        public int GuestRequestKey { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MailAddress { get; private set; }
        public Request_Statut Status { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime EntryDate { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public Location Area { get; private set; }
        public int SubArea { get; private set; }
        public Hosting_Type Type { get; private set; }
        public int Adults { get; private set; }
        public int children { get; private set; }
        public Preferences Pool { get; private set; }
        public Preferences Jacuzzi { get; private set; }
        public Preferences Garden { get; private set; }
        public Preferences ChildrensAttractions { get; private set; }
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
