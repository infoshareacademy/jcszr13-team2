using HotelHero.WebMVC.Interface;
using HotelHero.WebMVC.Models;
using Newtonsoft.Json;

namespace HotelHero.WebMVC.Services
{
    public class FileOperationService : IFileOperationService
    {
        private string PathMVC()
        {
            var path = @$"{AppDomain.CurrentDomain.BaseDirectory}/../../../Users/users.txt";
            string newPath = path;
            if (path.Contains(".WebMVC"))
            {
                newPath = path.Replace(".WebMVC", "");
            }
            return newPath;
        }

        public void SerializeFile(List<User> users)
        {
            var json = JsonConvert.SerializeObject(users);
            File.WriteAllText(PathMVC(), json);
        }

        public List<User> DeserializeFile()
        {
            var jsonUsers = File.ReadAllText(PathMVC());
            var users = JsonConvert.DeserializeObject<List<User>>(jsonUsers);
            return users;
        }
    }
}
