using HotelHero.ReservationsDatabase;
using System.ComponentModel.DataAnnotations;

namespace HotelHero.WebMVC.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public Reservation Reservation { get; set; }
        public List<AdditionalService> AdditionalServices { get; set; }
        public decimal TotalCost { get; set; }

        public Payment()
        {    
        }

        public Payment(int id, int userId, Reservation reservation, List<AdditionalService> additionalServices)
        {
            PaymentId = id;
            UserId = userId;
            Reservation = reservation;
            AdditionalServices = additionalServices;
        }

        public decimal GetAddiionalSevicesCost()
        {
            decimal additionalServicesCost = 0m;
            foreach (var service in AdditionalServices)
            {
                if (service.IsSelected)
                {
                    additionalServicesCost += service.Cost;
                }
            }
            return additionalServicesCost;
        }
        public decimal GetTotalCost()
        {
            var additionalServicesCost = GetAddiionalSevicesCost();
            var reservationCost = Reservation.GetReservationCost();
            TotalCost = additionalServicesCost + reservationCost;
            return TotalCost;
        }
    }
}
