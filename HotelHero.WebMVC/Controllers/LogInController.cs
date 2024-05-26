using HotelHero.UserPanel;
using HotelHero.WebMVC.Models;
using HotelHero.WebMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelHero.WebMVC.Controllers
{
    public class LogInController : Controller
    {
        private readonly ILogger<LogInController> _logger;
        private LogInService _logInService;

        public LogInController(ILogger<LogInController> logger)
        {
            _logger = logger;
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
                _logInService.LogIn(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
