using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.Database.Entities
{
    public class AdditionalServiceDTO
    {
        [Key]
        public int AdditionalServiceId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public bool IsSelected { get; set; }
        //public ICollection<PaymentAdditionalService> PaymentAdditionalServices { get; set; }
        //[ForeignKey(nameof(Payment))]
        //public int PaymentId { get; set; }
        //public Payment Payment { get; set; }
    }
}
