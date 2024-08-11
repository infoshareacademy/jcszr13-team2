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
        public int Id { get; set; }
        [ForeignKey(nameof(Hotel))]
        [Required]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int AmountOfPeople { get; set; }
        public decimal CostPerNight { get; set; }
        public int Status { get; set; }

        [ForeignKey(nameof(CustomerData))]
        public int CustomerDataId { get; set; }
        public CustomerData CustomerData{ get; set; }

        public int? PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
