using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.UserPanel
{
    internal class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public static string MaskedInput()
        {
            string input = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    input += key.KeyChar;
                    Console.Write("*"); // Display "*" instead of the actual character
                }
                else if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = input.Remove(input.Length - 1);
                    Console.Write("\b \b"); // Move cursor back, erase character, move cursor back again
                }
            } while (key.Key != ConsoleKey.Enter);

            return input;
        }
    }
}
