using HotelHero.ReservationsDatabase;
using HotelHero.UserPanel.Enums;

namespace HotelHero.WebMVC.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
        public List<Reservation> Reservations { get; set; }

        public User()
        {
            
        }
        public User(string email, string password, UserRole userRole, List<Reservation> reservations)
        {
            Email = email;
            Password = password;
            UserRole = userRole;
            Reservations = reservations;

        }
    }
}
