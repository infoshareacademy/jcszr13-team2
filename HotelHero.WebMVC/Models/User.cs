using HotelHero.ReservationsDatabase;
using HotelHero.UserPanel.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelHero.WebMVC.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }


        public User()
        {
            
        }
        public User(int id, string email, string password, UserRole userRole)
        {
            UserId = id;
            Email = email;
            Password = password;
            UserRole = userRole;


        }
    }
}
