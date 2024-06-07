using HotelHero.UserPanel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HotelHero
{
    public class CustomerData
    {
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool Rodo { get; set; }
        public bool Newsletter { get; set; }


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
        public static void InputData()
        {
            CustomerData cd = new CustomerData();
            cd.Email = Program.loggedUser.Email;

            Console.WriteLine("Please enter you data.");
            Console.WriteLine("Do you accept RODO?");
            cd.Rodo = bool.Parse(Console.ReadLine());
            Console.WriteLine("Last Name");
            cd.LastName = Console.ReadLine();
            Console.WriteLine("First Name");
            cd.FirstName = Console.ReadLine();
            Console.WriteLine("Date of Birth");
            cd.DateOfBirth = Console.ReadLine();
            Console.WriteLine("Address");
            cd.Address = Console.ReadLine();
            Console.WriteLine("Phone");
            cd.Phone = Console.ReadLine();
            Console.WriteLine("Do you want to receive newsletter?");
            cd.Newsletter = bool.Parse(Console.ReadLine());

            //var customerData = new List<string>
            //{
            //    cd.Email,
            //    cd.Rodo,
            //    cd.LastName,
            //    cd.FirstName,
            //    cd.DateOfBirth,
            //    cd.Address,
            //    cd.Phone,
            //    cd.Newsletter
            //};

            var json = JsonSerializer.Serialize(cd);
            File.WriteAllText(@$"{AppDomain.CurrentDomain.BaseDirectory}/../../../CustomerFiles/" + cd.Email + ".txt", json);
            CustomerDataMenu();
        }
        public void InputData(CustomerData customer)
        {
            var json = JsonSerializer.Serialize(customer);
            File.WriteAllText(PathMVC(), json);
        }
        private string PathMVC()
        {
            var path = @$"{AppDomain.CurrentDomain.BaseDirectory}/../../../Users/users.txt";
            string newPath = path;
            if (path.Contains(".WebMVC"))
            {
                newPath = path.Replace(".WebMVC", "");
            }
            return newPath;
        }
        public static void ReadData()
        {
            CustomerData cd = new CustomerData();
            cd.Email = Program.loggedUser.Email;

            var outputString = File.ReadAllText(@$"{AppDomain.CurrentDomain.BaseDirectory}/../../../CustomerFiles/" + cd.Email + ".txt");

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
