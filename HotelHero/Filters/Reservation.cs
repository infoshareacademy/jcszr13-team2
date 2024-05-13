using HotelHero.HotelsDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.Filters
{
    internal class Reservation
    {
        public Hotel Hotel { get; }
        public DateTime ChecInDate { get; }
        public DateTime CheckOutDate { get; }
        public int AmountOfPeople { get; }
        public Reservation(Hotel hotel, DateTime checkInDate, DateTime checkOutDate, int amountOfPeople)
        {
            Hotel = hotel;
            ChecInDate = checkInDate;
            CheckOutDate = checkOutDate;
            AmountOfPeople = amountOfPeople;
        }
    }
}
