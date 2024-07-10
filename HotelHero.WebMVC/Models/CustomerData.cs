using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HotelHero.WebMVC.Models
{
    public class CustomerData
    {
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<int> Favourites { get; set; }
        public bool Rodo { get; set; }
        public bool Newsletter { get; set; }

        public CustomerData(string email, string lastName, string firstName, string dateOfBirth, string address, string phone, List<int> favourites, bool rodo, bool newsletter)
        {
            Email = email;
            LastName = lastName;
            FirstName = firstName;
            DateOfBirth = dateOfBirth;
            Address = address;
            Phone = phone;
            Favourites = favourites;
            Rodo = rodo;
            Newsletter = newsletter;
        }

        public CustomerData()
        {
        }
    }
}
