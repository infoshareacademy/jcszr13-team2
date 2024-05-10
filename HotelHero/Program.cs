using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;
using HotelHero.UserPanel;

namespace HotelHero
{
    internal class Program
    {
        public static User loggedUser;
        static void Main(string[] args)
        {
            //var usersFile = new CreateUsers();
            //usersFile.CreateUsersFile();

            UserMenu.Menu();
        }
    }
}
