using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
   public enum ID
    {
        ID, PASSPORT, DRIVER_LICENSE
    }
  public enum Status
    {
        ACTIVE, INACTIVE
    }
    public enum Hosting_Type
    {
        ZIMMER, APARTMENT, HOTEL, CAMPING
    };
    public  enum Location
    {
        ALL, NORTH, SOUTH, CENTER, JERUSALEM
    };
    public enum Order_Status
    {
       APPROVED, PENDING, EMAIL_SENT, IGNORED_CLOSED, CLIENT_CLOSED,  IRRELEVANT
    };
    public enum Request_Statut
    {
        OPEN, EXPIRED, CANCELLED, ORDERED
    };
    public  enum Preferences
    {
        YES, MAYBE, NO
    };
}

