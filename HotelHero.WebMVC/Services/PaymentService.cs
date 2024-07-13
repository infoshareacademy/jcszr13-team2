using HotelHero.ReservationsDatabase;
using HotelHero.WebMVC.Interface;
using HotelHero.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelHero.WebMVC.Services
{
    public class PaymentService : IPaymentService
    {
        public Reservation reservation;

        public void AddBalance(User user, float balance)
        {
        }

        public void ProcessPayment(Reservation reservation)
        {
            this.reservation = reservation;
        }
        public Reservation GetReservation()
        {
            return this.reservation;
        }
    }
}
