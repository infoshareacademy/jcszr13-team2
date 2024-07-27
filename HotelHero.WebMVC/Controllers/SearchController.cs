using HotelHero.HotelsDatabase;
using HotelHero.ReservationsDatabase;
using HotelHero.ReservationsDatabase.Enums;
using HotelHero.WebMVC.Interface;
using HotelHero.WebMVC.Models;
using HotelHero.WebMVC.Services;
using HotelHero.WebMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelHero.WebMVC.Controllers
{
    public class SearchController : Controller
    {
        private readonly SearchPanel _searchService;
        private readonly IReservationService _reservationService;
        private readonly ICustomerDataService _customerDataService;
        private readonly IPaymentService _paymentService;

        public SearchController(IReservationService reservationService, ICustomerDataService customerDataService,IPaymentService paymentService)
        {
            _reservationService = reservationService;
            _customerDataService = customerDataService;
            _searchService = new SearchPanel();
            _paymentService = paymentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Results(SearchViewModel vm)
        {
            var items = _reservationService.GetReservation(vm.City, vm.StartDate, vm.EndDate, vm.PeopleAmount);
            return View(items);
        }

        public ActionResult MakeReservation(int id)
        {
            var model = _reservationService.GetReservationById(id);
            model.MakeReservation(UserContext.loggedUser.Email);
            _customerDataService.MakeReservation(UserContext.loggedUser.UserId, model);
            var payment = _paymentService.CreatePayment(UserContext.loggedUser.UserId, model);
            return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Payment", action = "Index", Id = payment.PaymentId }));
		}
    }
}
