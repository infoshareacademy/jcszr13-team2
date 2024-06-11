using HotelHero.ReservationsDatabase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelHero.UserPanel.Enums;

namespace HotelHero.UserPanel
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
        public List<Reservation> Reservations { get; set; }

        public User()
        {
            Reservations = new List<Reservation>();
        }

        public User(string email, string password,UserRole userRole, List<Reservation> reservations)
        {
            Email = email;
            Password = password;
            UserRole = userRole;
            Reservations = reservations;

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

        public void MakeReservation(Reservation newReservation)
        {
            Reservations.Add(newReservation);
        }
    }
}
