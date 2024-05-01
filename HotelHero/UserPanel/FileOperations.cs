using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.UserPanel
{
    internal class FileOperations
    {
        public void SerializeFile(List<User> users)
        {
            var json = JsonConvert.SerializeObject(users);
            File.WriteAllText("users.txt", json);
        }

        public List<User> DeserializeFile()
        {
            var jsonUsers = File.ReadAllText("users.txt");
            var users = JsonConvert.DeserializeObject<List<User>>(jsonUsers);

            return users;
        }
    }
}
