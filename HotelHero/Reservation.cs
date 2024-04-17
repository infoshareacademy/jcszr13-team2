using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero
{
    public class Reservation
    {
        public int ReservationNumber { get; set; }
        public string UserEmail { get; set; }
        public int Price { get; set; }

        public Reservation(int reservationnumber, string useremail, int price)
        {
            ReservationNumber = reservationnumber;
            UserEmail = useremail;
            Price = price;
        }





    }
}
