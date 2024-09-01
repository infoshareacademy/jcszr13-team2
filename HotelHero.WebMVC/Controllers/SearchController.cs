using HotelHero.HotelsDatabase;
using HotelHero.ReservationsDatabase;
using HotelHero.ReservationsDatabase.Enums;
using HotelHero.WebMVC.Interface;
using HotelHero.WebMVC.Models;
using HotelHero.WebMVC.Services;
using HotelHero.WebMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace HotelHero.WebMVC.Controllers
{
    public class SearchController : Controller
    {
        private readonly SearchPanel _searchService;
        private readonly IReservationService _reservationService;
        private readonly ICustomerDataService _customerDataService;
        private readonly IPaymentService _paymentService;

        public SearchController(IReservationService reservationService, ICustomerDataService customerDataService, IPaymentService paymentService)
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
            var items = _reservationService.SearchForReservations(city, startDate, endDate, peopleAmount);
            
            SearchResultsViewModel results = new SearchResultsViewModel();

            results.City = city;
            results.StartDate = startDate;
            results.EndDate = endDate;
            results.PeopleAmount = peopleAmount;
            results.Reservations = items;

            return View(results);
        }

        [HttpPost]
        public IActionResult ResultsWithFilters(SearchResultsViewModel vm)
        {
            // Sprawdzenie, czy parametry są podane i ustawienie ich na null, jeśli nie
            var city = string.IsNullOrEmpty(vm.City) ? null : vm.City;
            var startDate = vm.StartDate == default ? null : vm.StartDate;
            var endDate = vm.EndDate == default ? null : vm.EndDate;
            var peopleAmount = vm.PeopleAmount > 0 ? vm.PeopleAmount : (int?)null;
            var costPerNight = vm.CostPerNight > 0 ? vm.CostPerNight : (decimal?)null;
            var stars = vm.Stars > 0 && vm.Stars < 6 ? vm.Stars : (int?)null;
            var rating = vm.Rating > 0 && vm.Rating < 6 ? vm.Rating : (int?)null;

            // Wywołanie usługi z potencjalnie null wartościami
            var items = _reservationService.SearchWithFiltersForReservations(city, startDate, endDate, peopleAmount, costPerNight, stars, rating, vm.IsFreeWiFi, vm.IsPrivateParking, vm.IsRestaurant, vm.IsBar);

            SearchResultsViewModel results = new SearchResultsViewModel();

            results.City = city;
            results.StartDate = startDate;
            results.EndDate = endDate;
            results.PeopleAmount = peopleAmount;
            results.CostPerNight = costPerNight;
            results.Reservations = items;


            return View("Results", results);
        }

        public ActionResult MakeReservation(int id)
        {
            if(UserContext.loggedUser == null)
            {

            };
            var model = _reservationService.GetReservationById(id);
            _reservationService.MakeReservation(id, UserContext.loggedUser.Email);
            //model.MakeReservation(UserContext.loggedUser.Email);
            _customerDataService.MakeReservation(UserContext.loggedUser.UserId, model);
            var payment = _paymentService.CreatePayment(UserContext.loggedUser.UserId, model);
            return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Payment", action = "Index", Id = payment.PaymentId }));
        }
        public ActionResult RedirectToLogin()
        { 
            return RedirectToAction("LogIn", "LogIn");
        }

    }
}
