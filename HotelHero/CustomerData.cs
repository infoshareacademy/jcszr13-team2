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

        public static void CustomerDataMenu()
        {
            Console.WriteLine("Input Data");
            Console.WriteLine("Read Data");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    InputData();
                    break;
                case 2:
                    ReadData();
                    break;
                

            }
        }
        private static void InputData()
        {
            CustomerData cd = new CustomerData();
            cd.email = Program.loggedUser.Email;

            Console.WriteLine("Give data");
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

            var customerData = new List<string>
            {
                cd.email,
                cd.lastName,
                cd.firstName,
                cd.dateOfBirth,
                cd.address,
                cd.phone
            };

            var json = JsonSerializer.Serialize(customerData);
            File.WriteAllText(cd.email+".txt", json);
            CustomerDataMenu();
        }
        private static void ReadData() 
        {
            CustomerData cd = new CustomerData();
            cd.email = Program.loggedUser.Email;
            
            var outputString = File.ReadAllText(cd.email + ".txt");
            
            var customerData = JsonSerializer.Deserialize<List<string>>(outputString);
            foreach (var data in customerData)
            {
                Console.WriteLine(data.ToString());
            }
            CustomerDataMenu();
        }
    }
}
