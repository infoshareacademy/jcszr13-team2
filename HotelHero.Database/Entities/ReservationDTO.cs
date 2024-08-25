using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.Database.Entities
{
    public class ReservationDTO
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Hotel))]
        [Required]
        public int HotelId { get; set; }
        public HotelDTO Hotel { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int AmountOfPeople { get; set; }
        public decimal CostPerNight { get; set; }
        public int Status { get; set; }

        [ForeignKey(nameof(CustomerData))]
        public int? CustomerDataId { get; set; }
        public CustomerDataDTO CustomerData{ get; set; }

        public int? PaymentId { get; set; }
        public PaymentDTO Payment { get; set; }
    }
}
