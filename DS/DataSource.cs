using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;


namespace DS
{
    static public class DataSource
    {
        public static List<Person> persons;
        public static List<Host> hosts;
        public static List<HostingUnit> hostingUnits;
        public static List<Order> orders;
        public static List<GuestRequest> guestRequests;
        public static List<BankBranch> bankBranches;
        static DataSource()
        {
            persons = new List<Person>()
            {
                new Person()
                {
                    Id = 123,
                    IdType = ID.ID,
                    Status = Status.ACTIVE,
                    Password = 1111,
                    FirstName = "dan",
                    LastName = "ziber",
                    PhoneNumber = 100,
                    MailAddress = "jkj@hj.com",
                },
                new Person()
                {
                    Id = 122898,
                    IdType = ID.PASSPORT,
                    Status = Status.ACTIVE,
                    Password = 199111,
                    FirstName = "ophir",
                    LastName = "Jaguar",
                    PhoneNumber = 102,
                    MailAddress = "jkj@pp.com",
                }

            };
            hosts = new List<Host>()
            {
                new Host()
                {
                    HostID = 9898,
                    BankNumber = 11,
                    BranchNumber = 196,
                    BankAccuontNumber = 1111111,
                    CollectionClearance = true

                }
            };
            hostingUnits = new List<HostingUnit>()
            {
                new HostingUnit()
                {
                    Key = 1113,
                    Owner = 99,
                    HostingUnitName = "blue sky",
                    Diary = new bool[12, 31]
                }

            };
            guestRequests = new List<GuestRequest>()
            {
                new GuestRequest()
                {
                    GuestRequestKey = 123123123,
                    FirstName = "yosi",
                    LastName = "TOTO",
                    MailAddress = "rede24@gmial.com",
                    Status = Request_Statut.OPEN,
                    RegistrationDate = DateTime.Now,
                    EntryDate = new DateTime(2019, 12, 23),
                    ReleaseDate = new DateTime(2019, 12, 29),
                    Area = Location.CENTER,
                    SubArea = 0,
                    Type = Hosting_Type.ZIMMER,
                    Adults = 6,
                    children = 0,
                    Pool = Preferences.YES,
                    Jacuzzi = Preferences.YES,
                    Garden = Preferences.YES,
                    ChildrensAttractions = Preferences.NO
                }

            };
            bankBranches = new List<BankBranch>()
            {
                new BankBranch()
                {
                    BankName= "BOA",
                    BankNumber= 12,
                    BranchAddress = "11213 Brooklyn NY",
                    BranchCity = "NYC baby",
                    BranchNumber= 770

                },
                 new BankBranch()
                {
                    BankName= "BOA",
                    BankNumber= 12,
                    BranchAddress = "11213 crown",
                    BranchCity = "atlanta",
                    BranchNumber= 999

                },
                  new BankBranch()
                {
                    BankName= "BOA",
                    BankNumber= 12,
                    BranchAddress = "11213 hollywood",
                    BranchCity = "los angels",
                    BranchNumber= 396

                },
                   new BankBranch()
                {
                    BankName= "BOA",
                    BankNumber= 12,
                    BranchAddress = "167 miami beach",
                    BranchCity = "miami",
                    BranchNumber= 543

                },
                    new BankBranch()
                {
                    BankName= "BOA",
                    BankNumber= 12,
                    BranchAddress = "768 vhj",
                    BranchCity = "boston",
                    BranchNumber= 770

                },

            };
            orders = new List<Order>()
            {
                new Order()
                {
                    Key = 123123123,
                    HostingUnitKey = 770,
                    GuestRequestKey = 9911,
                    Status = Order_Status.IGNORED_CLOSED,
                    OrderDate =new DateTime(2019, 12, 23),
                    SentDate = new DateTime(2019, 12, 25),
                    CloseDate = new DateTime (2020, 1,1)               }
            };

        }
    }
}
