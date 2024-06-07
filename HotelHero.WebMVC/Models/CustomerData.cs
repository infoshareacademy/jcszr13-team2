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
        public bool Rodo { get; set; }
        public bool Newsletter { get; set; }
    }
}
