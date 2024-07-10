using HotelHero.WebMVC.Models;

namespace HotelHero.WebMVC.Interface
{
    public interface IPaymentService
    {
        void AddBalance(User user, float balance);
    }
}
