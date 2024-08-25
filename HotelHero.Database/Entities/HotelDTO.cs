using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.Database.Entities
{
    public class HotelDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Stars { get; set; }
        public float Rating { get; set; }
        public bool IsFreeWiFi { get; set; }
        public bool IsPrivateParking { get; set; }
        public bool IsRestaurant { get; set; }
        public bool IsBar { get; set; }
    }
}
