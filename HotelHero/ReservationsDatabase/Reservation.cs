using HotelHero.HotelsDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.ReservationsDatabase
{
    public class Reservation
    {
        public Hotel Hotel { get; }
        public DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }
        public int AmountOfPeople { get; }
        public int CostPerNight { get; }
        public Reservation(Hotel hotel, DateTime checkInDate, DateTime checkOutDate, int amountOfPeople, int costPerNight)
        {
            Hotel = hotel;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            AmountOfPeople = amountOfPeople;
            CostPerNight = costPerNight;

        }

        public override string ToString()
        {
            string result = "";
            result+= Hotel.ToString();
            result+= "\nCheck-in date: " + CheckInDate.ToString();
            result += "\nCheck-out date: " + CheckOutDate.ToString();
            result += "\nAmount of people:" + AmountOfPeople;
            return result;
        }
    }
}
