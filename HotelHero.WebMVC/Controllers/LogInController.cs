using HotelHero.ReservationsDatabase;
using HotelHero.WebMVC.Interface;
using HotelHero.WebMVC.Models;
using HotelHero.WebMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelHero.WebMVC.Controllers
{
    public class LogInController : Controller
    {
        private readonly ILogInService _logInService;
        private readonly ICustomerDataService _customerDataService;
        private readonly IFileOperationService _fileOperationService;

        public LogInController(ILogInService logService, ICustomerDataService customerDataService, IFileOperationService fileOperationService)
        {
            _logInService = logService;
            _customerDataService = customerDataService;
            _fileOperationService = fileOperationService;
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
                //if (!ModelState.IsValid)
                //{
                //    return View(user);
                //}
                _logInService.LogIn(user);
                return RedirectToAction(nameof(HomeController.Index), "Search");
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
        public IActionResult Register(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }
                var registeredUser = _fileOperationService.CreateUser(user.Email, user.Password);
                _logInService.LogIn(registeredUser);
                return RedirectToAction("RegisterCustomerData");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult RegisterCustomerData()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterCustomerData(CustomerData customerData)
        {
            var data = new CustomerData(
                UserContext.loggedUser.UserId,
                UserContext.loggedUser.Email,
                customerData.LastName,
                customerData.FirstName,
                customerData.DateOfBirth,
                customerData.Address,
                customerData.Phone,
                new List<Reservation>(),
                new List<int>(),
                customerData.Rodo,
                customerData.Newsletter,
                0m
                );

            _customerDataService.CreateCustomerData(data);
            return RedirectToAction("Index", "Home");
        }
    }
}
