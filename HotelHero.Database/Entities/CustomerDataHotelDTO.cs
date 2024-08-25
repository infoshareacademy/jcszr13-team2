using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.Database.Entities
{
    public class CustomerDataHotelDTO
    {
        [Key]
        public int CustomerDataHotelId { get; set; }
        [ForeignKey(nameof(CustomerData))]
        public int CustomerDataId { get; set; }
        public CustomerDataDTO CustomerData { get; set; }
        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }
        public HotelDTO Hotel { get; set; }
    }
}
