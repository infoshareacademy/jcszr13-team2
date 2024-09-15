using HotelHero.UserPanel.Enums;
using HotelHero.WebMVC.Interface;
using HotelHero.WebMVC.Models;
using Newtonsoft.Json;
using User = HotelHero.WebMVC.Models.User;

namespace HotelHero.WebMVC.Services
{
    public class FileOperationService : IFileOperationService
    {
        private readonly string _filePath = @$"{AppDomain.CurrentDomain.BaseDirectory}/../../../Data/Users.json";
        private List<User>? _users;
        //public FileOperationService()
        //{
        //    _users = new List<User>()
        //    {
        //        new(0, "admin", "admin", UserRole.Admin)
        //    };
        //    SaveUsers(_users);
        //}
        public List<User> GetUsers()
        {
            if (File.Exists(_filePath))
            {
                var usersJson = File.ReadAllText(_filePath);
                _users = JsonConvert.DeserializeObject<List<User>>(usersJson);
            }
            else
            {
                _users = new();
            }
            return _users;
        }
        public void SaveUsers(List<User> users)
        {
            var usersJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(_filePath, usersJson);
        }
        public User GetUser(int id)
        {
            var users = GetUsers();
            var user = users.Find(x => x.UserId == id);
            return user;
        }
        public User CreateUser(string email, string password)
        {
            var users = GetUsers();
            var user = new User(GetNewUserId(), email, password, UserRole.User);
            users.Add(user);
            SaveUsers(users);
            return user;
        }
        public void EditUser(int id, User user)
        {
            var users = GetUsers();
            var userIndex = users.FindIndex(x => x.UserId == id);
            users[userIndex] = user;
            SaveUsers(users);
        }
        public void DeleteUser(int id)
        {
            var users = GetUsers();
            var user = users.Find(x => x.UserId == id);
            users.Remove(user);
            SaveUsers(users);
        }
        private int GetNewUserId()
        {
            var userId = GetUsers().Last().UserId + 1;
            return userId;
        }

    }
}
