using HotelHero.UserPanel;
using HotelHero.WebMVC.Interface;
using HotelHero.WebMVC.Models;
using HotelHero.WebMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelHero.WebMVC.Controllers
{
    public class LogInController : Controller
    {
        private readonly ILogInService _logInService;

        public LogInController(ILogInService logService)
        {
            _logInService = logService;
        }
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }
                UserContext.SetUser(_logInService.LogIn(user));
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }
                _logInService.Register(user);
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

    }
}
