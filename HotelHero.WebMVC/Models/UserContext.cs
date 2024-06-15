using HotelHero.UserPanel;

namespace HotelHero.WebMVC.Models
{
    public static class UserContext
    {
        public static User loggedUser;

        public static User GetUser()
        {
            return loggedUser;
        }

        public static void SetUser(User user)
        {
            loggedUser = user;
        }
    }
}
