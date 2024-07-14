﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
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

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; set; }

        public CustomerData()
        {
        }
        public CustomerData(string email, string lastName, string firstName, string dateOfBirth, string address, string phone, List<int> favourites, bool rodo, bool newsletter, decimal balance)
        {
            Email = email;
            LastName = lastName;
            FirstName = firstName;
            DateOfBirth = dateOfBirth;
            Address = address;
            Phone = phone;
            Favourites = favourites;
            Newsletter = newsletter;
            Rodo = rodo;
            Balance = balance;
        }

    }
}
