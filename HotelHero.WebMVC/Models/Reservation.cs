using HotelHero.WebMVC.Models.Enums;

namespace HotelHero.WebMVC.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Hotel Hotel { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int AmountOfPeople { get; set; }
        public decimal CostPerNight { get; set; }
        public ReservationStatus Status { get; set; }
        public string ReservationUser { get; set; }

        //public Reservation(int id, Hotel hotel, DateTime checkInDate, DateTime checkOutDate, int amountOfPeople, decimal costPerNight, ReservationStatus reservationStatus, string reservationUser)
        //{
        //    Id = id;
        //    Hotel = hotel;
        //    CheckInDate = checkInDate;
        //    CheckOutDate = checkOutDate;
        //    AmountOfPeople = amountOfPeople;
        //    CostPerNight = costPerNight;
        //    Status = reservationStatus;
        //    ReservationUser = reservationUser;
        //}

        public Reservation()
        {
            Hotel = new Hotel();
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
        public decimal GetReservationCost()
        {
            var from = CheckInDate < CheckOutDate ? CheckInDate : CheckOutDate;
            var to = CheckInDate < CheckOutDate ? CheckOutDate : CheckInDate;
            var totalDays = (int)(to - from).TotalDays;
            totalDays = totalDays > 1 ? totalDays : 1;
            var reservationCost = CostPerNight * totalDays;
            return reservationCost;
        }
    }
}
