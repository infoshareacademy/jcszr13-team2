using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.Database.Entities
{
    public class CustomerDataHotel
    {
        [Key]
        public int CustomerDataHotelId { get; set; }
        [ForeignKey(nameof(CustomerData))]
        public int CustomerDataId { get; set; }
        public CustomerData CustomerData { get; set; }
        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
