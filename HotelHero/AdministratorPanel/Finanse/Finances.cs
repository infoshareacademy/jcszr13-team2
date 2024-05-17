using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.AdministratorPanel.Finanse
{
    internal class Finances
    {
        public static void Finance()
        {
            Console.WriteLine("You are in finance");
            Console.WriteLine("1.Reports - (Comming soon)");
            Console.WriteLine("2.Statistics - (Comming soon)");
            Console.WriteLine("3.Expenses and revenues - (Comming soon)");
            Console.WriteLine("4.Back");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Reports();
                    break;
                case 2:
                    Statistics();
                    break;
                case 3:
                    ExpAndRev();
                    break;
                case 4:
                    AdministratorPanel.PanelAd();
                    break;
            }
        }
        static void Reports()
        {
            Console.WriteLine(" ");
            Console.WriteLine();
        }
        static void Statistics()
        {
            Console.WriteLine("");
            Console.WriteLine();
        }

        static void ExpAndRev()
        {
            Console.WriteLine("");
            Console.WriteLine();
        }
    }
    }
