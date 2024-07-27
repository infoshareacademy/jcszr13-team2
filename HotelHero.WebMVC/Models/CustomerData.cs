using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;
using HotelHero.ReservationsDatabase;

namespace HotelHero.WebMVC.Models
{
    public class CustomerData
    {
        [Key]
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<Reservation> Reservations { get; set; }
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
        public CustomerData(int id, string email, string lastName, string firstName, DateTime dateOfBirth, string address, string phone, List<Reservation> reservations, List<int> favourites, bool rodo, bool newsletter, decimal balance)
        {
            CustomerId = id;
            Email = email;
            LastName = lastName;
            FirstName = firstName;
            DateOfBirth = dateOfBirth;
            Address = address;
            Phone = phone;
            Reservations = reservations;
            Favourites = favourites;
            Newsletter = newsletter;
            Rodo = rodo;
            Balance = balance;
        }

    }
}
