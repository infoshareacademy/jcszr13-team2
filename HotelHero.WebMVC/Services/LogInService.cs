using HotelHero.ReservationsDatabase;
using HotelHero.UserPanel.Enums;
using HotelHero.WebMVC.Interface;
using HotelHero.WebMVC.Models;

namespace HotelHero.WebMVC.Services
{
    public class LogInService : ILogInService
    {
        private User loggedUser;
        private IFileOperationService _fileOperationService;
        public LogInService(IFileOperationService fileOperationService)
        {
            _fileOperationService = fileOperationService;   
        }
        public void LogIn(User logInUser)
        {
            var users = _fileOperationService.GetUsers();
            loggedUser = users.Find(x => x.Email == logInUser.Email);
            if (loggedUser != null && loggedUser.Password == logInUser.Password) {
                UserContext.SetUser(loggedUser);
            }
        }

		public void LogOut()
		{
            UserContext.SetUser(null);
		}

		public void Register(User registerUser)
        {
            _fileOperationService.CreateUser(registerUser.Email, registerUser.Password);
        }
    }
}
