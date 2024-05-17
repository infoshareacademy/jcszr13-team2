using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.UserPanel
{
    internal class UserRegistration
    {
        public void Registration()
        {
            var email = "";
            var duplicatedEmail = true;
            User newUser = null;
            FileOperations fileOperations = new FileOperations();

            var users = fileOperations.DeserializeFile();

            while (duplicatedEmail)
            {
                Console.WriteLine("Enter Email");
                email = Console.ReadLine();

                duplicatedEmail = users.Any(x => x.Email == email);

                if (duplicatedEmail)
                    Console.WriteLine("The email address already exists in the system." +
                        " Please use a different email address.");
            }

            Console.WriteLine("Enter password");
            var password = User.MaskedInput();

            newUser = new User(email, password);

            users.Add(newUser);

            fileOperations.SerializeFile(users);
        }
    }
}



