using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.Database.Entities
{
    public class HotelUser : IdentityUser
    {
        
        public int CustomerDataId { get; set; }
        public CustomerData CustomerData { get; set; }
    }

}
