using HotelHero.UserPanel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HotelHero
{
    internal class CustomerData
    {
        string email;
        string lastName;
        string firstName;
        string dateOfBirth;
        string address;
        string phone;
        string rodo;
        string newsletter;

        public static void CustomerDataMenu()
        {
            try
            {
                string.IsNullOrEmpty(Program.loggedUser.Email);
            }
            catch (Exception ex)
            {
                Console.WriteLine("You are not logged in. Please log in.");
                CustomerPanel.Panel();
            }

            Console.WriteLine("1.Input Data");
            Console.WriteLine("2.Read Data");
            Console.WriteLine("3.Back");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    InputData();
                    break;
                case 2:
                    ReadData();
                    break;
                case 3:
                    CustomerPanel.Panel();
                    break;

            }
        }
        private static void InputData()
        {
            CustomerData cd = new CustomerData();
            cd.email = Program.loggedUser.Email;

            Console.WriteLine("Please enter you data.");
            Console.WriteLine("Do you accept RODO?");
            cd.rodo = Console.ReadLine();
            Console.WriteLine("Last Name");
            cd.lastName = Console.ReadLine();
            Console.WriteLine("First Name");
            cd.firstName = Console.ReadLine();
            Console.WriteLine("Date of Birth");
            cd.dateOfBirth = Console.ReadLine();
            Console.WriteLine("Address");
            cd.address = Console.ReadLine();
            Console.WriteLine("Phone");
            cd.phone = Console.ReadLine();
            Console.WriteLine("Do you want to receive newsletter?");
            cd.newsletter = Console.ReadLine();

            var customerData = new List<string>
            {
                cd.email,
                cd.rodo,
                cd.lastName,
                cd.firstName,
                cd.dateOfBirth,
                cd.address,
                cd.phone,
                cd.newsletter
            };

            var json = JsonSerializer.Serialize(customerData);
            File.WriteAllText(cd.email + ".txt", json);
            CustomerDataMenu();
        }
        private static void ReadData()
        {
            CustomerData cd = new CustomerData();
            cd.email = Program.loggedUser.Email;

            var outputString = File.ReadAllText(cd.email + ".txt");

            var customerData = JsonSerializer.Deserialize<List<string>>(outputString);
            var joinString = string.Join(",", customerData);
            string[] words = joinString.Split(',');
            Console.WriteLine("Email: " + words.GetValue(0));
            Console.WriteLine("Accepted RODO: " + words.GetValue(1));
            Console.WriteLine("Last Name: " + words.GetValue(2));
            Console.WriteLine("First Name: " + words.GetValue(3));
            Console.WriteLine("Date of birth: " + words.GetValue(4));
            Console.WriteLine("Address: " + words.GetValue(5));
            Console.WriteLine("Phone: " + words.GetValue(6));
            Console.WriteLine("Accepted newsletter: " + words.GetValue(7));

            CustomerDataMenu();
        }
    }
}
