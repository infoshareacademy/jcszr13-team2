using HotelHero.ReservationsDatabase;
using HotelHero.UserPanel;
using HotelHero.UserPanel.Enums;
using HotelHero.WebMVC.Interface;

namespace HotelHero.WebMVC.Services
{
    public class LogInService : ILogInService
    {
        public User? LogIn(User logInUser)
        {
            FileOperations fileOperations = new FileOperations();
            var users = fileOperations.DeserializeFile();
               
            
            User loggedUser = null;
            foreach (User user in users)
            {
                if (user.Email == logInUser.Email && user.Password == logInUser.Password)
                {
                    loggedUser = user;
                    break;
                }
            }
            if (loggedUser != null)
            {
                Console.WriteLine("\nYou are Logged In");
                return loggedUser;
            }
            else
            {
                Console.WriteLine("\nThe data provied is incorrect");
                return null;
            };
        }

        public void Register(User registerUser)
        {
            FileOperations fileOperations = new FileOperations();
            var users = fileOperations.DeserializeFile();

            var newUser = new User(registerUser.Email, registerUser.Password, UserRole.UnloggedUser,
                new List<Reservation>());
            users.Add(newUser);
            fileOperations.SerializeFile(users);
        }

    }
}
