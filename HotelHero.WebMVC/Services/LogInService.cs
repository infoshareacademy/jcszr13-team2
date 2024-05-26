using HotelHero.UserPanel;

namespace HotelHero.WebMVC.Services
{
    public class LogInService
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
        
    }
}
