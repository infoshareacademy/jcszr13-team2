using HotelHero.ReservationsDatabase;
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

        public static List<Reservation> GetReservation()
        {
            return loggedUser.Reservations;
        }
        public static void MakeReservation(Reservation newReservation)
        {
            loggedUser.Reservations.Add(newReservation);
        }
    }
}
