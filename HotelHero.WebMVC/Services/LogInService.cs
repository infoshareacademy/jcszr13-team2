using HotelHero.ReservationsDatabase;
using HotelHero.UserPanel.Enums;
using HotelHero.WebMVC.Interface;
using HotelHero.WebMVC.Models;

namespace HotelHero.WebMVC.Services
{
    public class LogInService : ILogInService
    {
        private IFileOperationService _fileOperationService;
        public LogInService(IFileOperationService fileOperationService)
        {
            _fileOperationService = fileOperationService;   
        }
        public User? LogIn(User logInUser)
        {
            var users = _fileOperationService.DeserializeFile();
               
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
            var users = _fileOperationService.DeserializeFile();

            var newUser = new User(registerUser.Email, registerUser.Password, UserRole.UnloggedUser, new List<Reservation>());
            users.Add(newUser);
            _fileOperationService.SerializeFile(users);
        }
    }
}
