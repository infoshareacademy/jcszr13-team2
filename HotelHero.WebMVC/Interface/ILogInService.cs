using HotelHero.UserPanel;

namespace HotelHero.WebMVC.Interface
{
    public interface ILogInService
    {
        User LogIn(User logInUser);
        void Register(User registerUser);

    }
}
