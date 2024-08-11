using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.Database.Entities
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
        public List<Payment> Payments { get; set; }
        public List<Reservation> Reservations { get; set; }
        public ICollection<CustomerDataHotel> CustomerDataHotel { get; set; }
        public bool Rodo { get; set; }
        public bool Newsletter { get; set; }

        public decimal Balance { get; set; }

        public CustomerData()
        {
            Reservations = new List<Reservation>();
            Payments = new List<Payment>();
        }
    }
}
