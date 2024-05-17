using HotelHero.UserPanel;
using System;

namespace HotelHero
{
    internal class UserMenu
    {
        public static void Menu()
        {
            if (Program.loggedUser != null && Program.loggedUser.IsAdmin == true)
            {
                AdministratorPanel.AdministratorPanel.PanelAd();
            }
            else
            {
                Console.WriteLine("Select an item from the list");
                Console.WriteLine("1.Language selection");
                Console.WriteLine("2.Currency selection (Coming soon)");
                Console.WriteLine("3.User registration");
                Console.WriteLine("4.User login");
                Console.WriteLine("5.Offer search");
                Console.WriteLine("6.Customer panel");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        LanguageSelection();
                        break;
                    case 2:
                        CurrencySelection();
                        break;
                    case 3:
                        UserRegistration();
                        break;
                    case 4:
                        UserLogin();
                        break;
                    case 5:
                        SearchPanel filtryOgólne = new SearchPanel();
                        filtryOgólne.OfferSearch();
                        Menu();
                        break;
                    case 6:
                        CustomerPanel.Panel();
                        break;
                }
            }
        }
        static void LanguageSelection()
        {
            Console.WriteLine("You are in Language selection");
            Console.WriteLine("Choose language");
            Console.WriteLine("1.Polski");
            Console.WriteLine("2.English");
            Console.WriteLine("3.Español");

            int language = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (language)
            {
                case 1:
                    Console.WriteLine("Wybrałeś język Polski");
                    break;
                case 2:
                    Console.WriteLine("You chose English - (Coming soon)");
                    break;
                case 3:
                    Console.WriteLine("Has elegido español - (Pronto)");
                    break;

            }
            Menu();
        }
        static void CurrencySelection()
        {
            Console.WriteLine("Select currency");
            Console.WriteLine("1.PLN");
            Console.WriteLine("2.EUR - (Coming soon)");
            Console.WriteLine("3.GBP - (Coming soon)");
            int currency = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (currency)
            {
                case 1:
                    Console.WriteLine("Ustawiono PLN");
                    break;
                case 2:
                    Console.WriteLine("Set EUR");
                    break;
                case 3:
                    Console.WriteLine("Set GBP");
                    break;
            }
            Menu();
        }

        static void UserRegistration()
        {
            var registration = new UserRegistration();
            registration.Registaration();
            Menu();
        }
        static void UserLogin()
        {
            var logIn = new UserLogIn();
            Program.loggedUser = logIn.LogIn();
            Console.WriteLine(Program.loggedUser?.Email);
            Menu();
        }
    }
}
