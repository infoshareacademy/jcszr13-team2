using Newtonsoft.Json;
using HotelHero;
using System.Collections.Generic;
using System.IO;
using System;
using HotelHero.UserPanel;

namespace MasterBooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var usersFile = new CreateUsers();
            usersFile.CreateUsersFile();

            UserMenu.Menu();
        }
    }
}
