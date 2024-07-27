using HotelHero.ReservationsDatabase;
using HotelHero.WebMVC.Models;
using HotelHero.WebMVC.Services;
using Newtonsoft.Json;

namespace HotelHero.WebMVC.Interface
{
    public interface IPaymentService
    {
        List<Payment> GetPaymentHistory();
        Payment GetPayment(int id);
        Payment CreatePayment(int userId, Reservation reservation);
        void SavePayment(Payment payment);
        Payment UpdatePayment(Payment payment);
        void CancelPayment(int paymentId);
    }
}
