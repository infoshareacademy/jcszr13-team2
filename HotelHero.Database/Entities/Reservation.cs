using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.Database.Entities
{
    public class Reservation
    {
        public int Id { get; }
        [ForeignKey(nameof(Hotel))]
        [Required]
        public int HotelId { get; set; }
        public Hotel Hotel { get; }
        public DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }
        public int AmountOfPeople { get; }
        public decimal CostPerNight { get; }
        public int Status { get; set; }
        public string ReservationUser { get; set; }
        public Payment? Payment { get; set; }
    }
}
