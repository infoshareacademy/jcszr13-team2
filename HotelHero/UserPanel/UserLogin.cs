using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.UserPanel
{
    internal class UserLogIn
    {
        public User? LogIn()
        {
            FileOperations fileOperations = new FileOperations();

            var users = fileOperations.DeserializeFile();
            Console.WriteLine("\nLog In");
            Console.WriteLine("\nEnter Email");
            var loginEmail = Console.ReadLine();
            Console.WriteLine("\nEnter Password");
            var loginPassword = Console.ReadLine();

            User loggedUser = null;
            foreach (User user in users)
            {
                if (user.Email == loginEmail && user.Password == loginPassword)
                {
                    loggedUser = user;
                    break;
                }
            }
            if (loggedUser != null)
            {
                Console.WriteLine("\nYou are Logged In");
                return loggedUser;
            }
            else
            {
                Console.WriteLine("\nThe data provied is incorrect");
                return null;
            };
        }
    }
}
