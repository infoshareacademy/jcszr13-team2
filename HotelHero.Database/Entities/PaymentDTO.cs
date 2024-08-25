using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.Database.Entities
{
    public class PaymentDTO
    {
        [Key]
        public int PaymentId { get; set; }

        [ForeignKey(nameof(CustomerData))]
        public int CustomerDataId { get; set; }
        public CustomerDataDTO CustomerData { get; set; }

        //[ForeignKey(nameof(Reservation))]
        //[Required]
        //public int ReservationId { get; set; }
        public ReservationDTO Reservation { get; set; }
        public ICollection<PaymentAdditionalServiceDTO> PaymentAdditionalServices { get; set; }
        public decimal TotalCost { get; set; }
    }
}
