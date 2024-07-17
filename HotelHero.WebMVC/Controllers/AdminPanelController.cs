using HotelHero.ReservationsDatabase;
using HotelHero.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using HotelHero.WebMVC.Interface;

namespace HotelHero.WebMVC.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IFileOperationService _fileOperationService;
        public AdminPanelController(IFileOperationService fileOperationService)
        {
            _fileOperationService = fileOperationService;
        }
        // GET: AdminPanelController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminPanelController/Users
        public ActionResult Users()
        {
            var model = _fileOperationService.DeserializeFile();
            return View(model);
        }

        // GET: AdminPanelController/Edit
        public ActionResult UserEdit(User user)
        {
            return View(user);
        }

        // POST: AdminPanelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEdit(string email, User user)
        {
            var users = _fileOperationService.DeserializeFile();
            var index = users.FindIndex(delegate (User user) { return user.Email == email; });
            users.Remove(users[index]);
            var editUser = new User(user.Email, user.Password, user.UserRole);
            users.Insert(index, editUser);
            _fileOperationService.SerializeFile(users);
            return RedirectToAction("Users");
        }
        
    }
}
