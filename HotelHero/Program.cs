using Newtonsoft.Json;
using HotelHero;
using System.Collections.Generic;

namespace MasterBooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //tworzenie pliku
            var newUser = new User("user1@email.hotelhero", "passwordValue");
            var users = new List<User>();
            users.Add(newUser);
            var json = JsonConvert.SerializeObject(users);
            File.WriteAllText("users.txt", json);

            var jsonUsers = File.ReadAllText("users.txt");
            users = JsonConvert.DeserializeObject<List<User>>(jsonUsers);
            var email = "";
            var duplicatedEmail = true;
            var option = 4;

            while (option == 4)
            {
                Console.WriteLine("\nMenu główne" +
                    "\nWybierz numer opcji:" +
                    "\n1. Zarejestruj nowego użytkownika" +
                    "\n2. Zaloguj się" +
                    "\n3. Wyjdź z aplikacji"
                    );
                option = int.Parse(Console.ReadLine());
                if (option == 3) return;

                while (option == 1)
                {
                    while (duplicatedEmail)
                    {
                        Console.WriteLine("Wprowadź Email");
                        email = Console.ReadLine();

                        foreach (User user in users)
                        {
                            if (user.Email == email)
                            {
                                Console.WriteLine("Adres e-mail już istnieje w systemie. Proszę użyć innego adresu e-mail lub zalogować się, jeśli już masz konto." +
                                    "\nWybierz opcje:" +
                                    "\n1. Wpisz inny adres e-mail" +
                                    "\n2. Zaloguj się" +
                                    "\n3. Wyjdź z aplikacji" +
                                    "\n4. Menu główne"
                                    );
                                option = int.Parse(Console.ReadLine());
                                switch (option)
                                {
                                    case 1:
                                        duplicatedEmail = true;
                                        continue;
                                    default:
                                        duplicatedEmail = false;
                                        break;
                                }
                            }
                            else
                            {
                                duplicatedEmail = false;
                            }
                        }
                    }
                    if (option == 1)
                    {
                        duplicatedEmail = true;
                        Console.WriteLine("Wprowadź hasło");
                        var password = Console.ReadLine();

                        newUser = new User(email, password);

                        users.Add(newUser);

                        json = JsonConvert.SerializeObject(users);

                        File.WriteAllText("users.txt", json);

                        option = 4;

                    }
                }

                //logowanie
                if (option == 2)
                {
                    jsonUsers = File.ReadAllText("users.txt");
                    users = JsonConvert.DeserializeObject<List<User>>(jsonUsers);
                    Console.WriteLine("\nZaloguj się");
                    Console.WriteLine("\nWprowadź Email");
                    var loginEmail = Console.ReadLine();
                    Console.WriteLine("\nWprowadź hasło");
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
                        Console.WriteLine("\nJesteś zalogowany");
                    }
                    else
                    {
                        Console.WriteLine("\nNieporpawne dane użytkownika");
                    };
                    option = 4;
                }

            }
        }
    }
}
