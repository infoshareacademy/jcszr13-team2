using HotelHero.WebMVC.Models;

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
