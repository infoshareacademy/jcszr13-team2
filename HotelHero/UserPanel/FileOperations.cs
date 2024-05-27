using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.UserPanel
{
    public class FileOperations

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