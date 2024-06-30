using HotelHero.ReservationsDatabase;
using HotelHero.UserPanel;
using HotelHero.UserPanel.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace HotelHero.WebMVC.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET: AdminPanelController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminPanelController/Users
        public ActionResult Users()
        {
            FileOperations fileOperations = new FileOperations();
            var model = fileOperations.DeserializeFile();
            return View(model);
        }

        // GET: AdminPanelController/Edit
        public ActionResult UserEdit(string email)
        {
            FileOperations fileOperations = new FileOperations();
            var users = fileOperations.DeserializeFile();
            User user = users.Find(delegate (User user) { return user.Email == email; });
            return View(user);
        }

        // POST: AdminPanelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEdit(string email, User user)
        {
            FileOperations fileOperations = new FileOperations();
            var users = fileOperations.DeserializeFile();
            var index = users.FindIndex(delegate (User user) { return user.Email == email; });
            users.Remove(users[index]);
            var editUser = new User(user.Email, user.Password, user.UserRole, new List<Reservation> ());
            users.Insert(index, editUser);
            fileOperations.SerializeFile(users);
            return RedirectToAction("Users");
        }
    }
}
