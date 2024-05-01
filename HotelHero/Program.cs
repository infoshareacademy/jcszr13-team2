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
            var registration = new UserRegistration();
            registration.Registaration();
            var logIn = new UserLogIn();
            var loggedInUser = logIn.LogIn();
            Console.WriteLine(loggedInUser.Email);
        }
    }
}
