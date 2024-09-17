using HotelHero.WebMVC.Models;

namespace HotelHero.WebMVC.Interface
{
    public interface ILogInService
    {
        void LogIn(User logInUser);
		void LogOut();
		void Register(User registerUser);

    }
}
