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
            // Sprawdzenie, czy parametry są podane i ustawienie ich na null, jeśli nie
            var city = string.IsNullOrEmpty(vm.City) ? null : vm.City;
            var startDate = vm.StartDate == default ? null : vm.StartDate;
            var endDate = vm.EndDate == default ? null : vm.EndDate;
            var peopleAmount = vm.PeopleAmount > 0 ? vm.PeopleAmount : (int?)null;

            // Wywołanie usługi z potencjalnie null wartościami
            var items = _reservationService.GetReservation(city, startDate, endDate, peopleAmount);
            return View(items);
        }

        public ActionResult MakeReservation(int id)
        {
            var model = _reservationService.GetReservationById(id);
            model.MakeReservation(UserContext.loggedUser.Email);
            _customerDataService.MakeReservation(model);
            _paymentService.ProcessPayment(model);
            return RedirectToAction("Index", "Payment");
        }
    }
}
