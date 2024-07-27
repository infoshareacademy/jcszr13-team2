using HotelHero.WebMVC.Models;

namespace HotelHero.WebMVC.Interface
{
    public interface IFileOperationService
    {
        public List<User> GetUsers();
        public void SaveUsers(List<User> users);
        public User GetUser(int id);
        public User CreateUser(string email, string password);
        public void EditUser(int Id, User user);
        public void DeleteUser(int Id);
    }
}
