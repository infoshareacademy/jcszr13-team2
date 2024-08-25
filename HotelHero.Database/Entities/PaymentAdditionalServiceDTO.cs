using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.Database.Entities
{
    public class PaymentAdditionalServiceDTO
    {
        [Key]
        public int PaymentAdditionalServiceId { get; set; }

        [ForeignKey(nameof(Payment))]
        public int PaymentId { get; set; }
        public PaymentDTO Payment { get; set; }

        [ForeignKey(nameof(AdditionalService))]
        public int AdditionalServiceId { get; set; }
        public AdditionalServiceDTO AdditionalService { get; set; }
    }
}
