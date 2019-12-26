using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    enum ID
    {
        ID, PASSPORT, DRIVER_LICENSE
    }
    enum Person_Status
    {
        ACTIVE, INACTIVED
    }
    enum Hosting_Type
    {
        ZIMMER, APARTMENT, HOTEL, CAMPING
    };
    enum Location
    {
        ALL, NORTH, SOUTH, CENTER, JERUSALEM
    };
    enum Order_Status
    {
        PENDING, EMAIL_SENT, IGNORED_CLOSED, CLIENT_CLOSED
    };
    enum Request_Statut
    {
        OPEN, EXPIRED, CANCELLED, ORDERED
    };
    enum Preferences
    {
        YES, MAYBE, NO
    };
}

