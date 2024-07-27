using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelHero
{
    internal class CustomerPanel
    {
        public static void Panel()
        {
            Console.WriteLine("1.Customer Data");
            Console.WriteLine("2.Your reservations");
            Console.WriteLine("3.History of stays");
            Console.WriteLine("4.Payment history (Coming soon)");
            Console.WriteLine("5.Favorite (Coming soon)");
            Console.WriteLine("6.Back to menu");

            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    //CustomerData.CustomerDataMenu();
                    break;
                case 2:
                    YourReservations();
                    break;
                case 3:
                    HistoryOfStays();
                    break;
                case 4:
                    PaymentHistory();
                    break;
                case 5:
                    FavoriteMenu.Favorite();
                    break;
                case 6:
                    UserMenu.Menu();
                    break;
            }
        }
        static void YourReservations()      
        {
            Console.WriteLine("Your reservations: ");
            foreach (var item in Program.loggedUser.Reservations)
            {
                Console.WriteLine(item.ToString());    
            }

            Console.WriteLine();
            Panel();
        }
        static void HistoryOfStays()
        {
            Console.WriteLine("lepiej pominąć");
            Console.WriteLine();
            Panel();
        }
        static void PaymentHistory()
        {
            Console.WriteLine("Tu powstanie zwariowane historie");
            Console.WriteLine();
            Panel();
        }
        static void Favorite()
        {
            Console.WriteLine("Tu powstanie zakręcone ulubione");
            Console.WriteLine();
            Panel();


        }
    }
}
