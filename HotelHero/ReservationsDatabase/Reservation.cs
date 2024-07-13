using HotelHero.HotelsDatabase;
using HotelHero.ReservationsDatabase.Enums;
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
        public int Id { get; }
        public Hotel Hotel { get; }
        public DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }
        public int AmountOfPeople { get; }
        public int CostPerNight { get; }
        public ReservationStatus Status { get; set; }
        public Reservation(int id, Hotel hotel, DateTime checkInDate, DateTime checkOutDate, int amountOfPeople, int costPerNight)
        {
            Id = id;
            Hotel = hotel;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            AmountOfPeople = amountOfPeople;
            CostPerNight = costPerNight;
            Status = ReservationStatus.Free;
        }

        public void UpdateReservationStatus(ReservationStatus status)
        {
            Status = status;
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
