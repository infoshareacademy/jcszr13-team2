using HotelHero.WebMVC.Models;

namespace HotelHero.WebMVC.Interface
{
    public interface ILogInService
    {
        void LogIn(User logInUser);
        void Register(User registerUser);

    }
}
