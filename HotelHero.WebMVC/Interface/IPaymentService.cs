using HotelHero.ReservationsDatabase;
using HotelHero.WebMVC.Models;

namespace HotelHero.WebMVC.Interface
{
    public interface IPaymentService
    {
        void ProcessPayment(Reservation reservation);
        Reservation GetReservation();
        void AddBalance(User user, float balance);
    }
}
