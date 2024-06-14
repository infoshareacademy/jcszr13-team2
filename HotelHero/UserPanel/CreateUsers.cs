using HotelHero.ReservationsDatabase;
using HotelHero.UserPanel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.UserPanel
{
    internal class CreateUsers
    {   public void CreateUsersFile()
        {
            var newUser1 = new User("user1@email.hotelhero", "passwordValue1",UserRole.UnloggedUser, new List<Reservation>());
            var newUser2 = new User("user2@email.hotelhero", "passwordValue2", UserRole.UnloggedUser, new List<Reservation>());
            var newUser3 = new User("user3@email.hotelhero", "passwordValue3", UserRole.UnloggedUser, new List<Reservation>());
            var newUser4 = new User("user4@email.hotelhero", "passwordValue4", UserRole.UnloggedUser, new List<Reservation>());
            var newUser5 = new User("admin", "admin", UserRole.Admin, new List<Reservation>());
            var users = new List<User>();
            users.Add(newUser1);
            users.Add(newUser2);
            users.Add(newUser3);
            users.Add(newUser4);
            users.Add(newUser5);

            FileOperations fileOperations = new FileOperations();

            fileOperations.SerializeFile(users);
        }
    }
}
