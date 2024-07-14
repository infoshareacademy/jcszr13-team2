using HotelHero.ReservationsDatabase;
using HotelHero.UserPanel.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelHero.WebMVC.Models
{
    public class User
    {
        //[Required]
        //[EmailAddress]
        public string Email { get; set; }
        //[Required]
        //[PasswordPropertyText]
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
