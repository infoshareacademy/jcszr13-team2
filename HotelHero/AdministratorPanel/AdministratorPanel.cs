using HotelHero.AdministratorPanel.Finanse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.AdministratorPanel
{
    internal class AdministratorPanel
    {
        public static void PanelAd()
        {
            Console.WriteLine("Select an item from the list");
            Console.WriteLine("1.Reservation management - individual client - (Comming soon)");
            Console.WriteLine("2.Reservation management - Business client - (Comming soon)");
            Console.WriteLine("3.Finances");
            Console.WriteLine("4.Marketing - (Comming soon)");
            Console.WriteLine("5.Employees - (Comming soon)");
            Console.WriteLine("6.Log out");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    RMInd();
                    break;
                case 2:
                    RMBiz();
                    break;
                case 3:
                    Finances.Finance();
                    break;
                case 4:
                    Marketing();
                    break;
                case 5:
                    Employees();
                    break;
                case 6:
                    LogOut();
                    break;
            }
        }

        static void RMInd()
        {
            Console.WriteLine(" ");
            Console.WriteLine();
        }
        static void RMBiz()
        {
            Console.WriteLine("");
            Console.WriteLine();
        }
       
        static void Marketing()
        {
            Console.WriteLine("");
            Console.WriteLine();
        }
        static void Employees()
        {
            Console.WriteLine("");
            Console.WriteLine();
        }
        static void LogOut()
        {
            Program.loggedUser = null;
            Console.Clear();
            Console.WriteLine("Logged out");
            UserMenu.Menu();
        }

    }
}
