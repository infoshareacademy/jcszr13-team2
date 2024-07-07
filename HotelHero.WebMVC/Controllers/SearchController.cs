using HotelHero.ReservationsDatabase;
using HotelHero.WebMVC.Interface;
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

        public SearchController(IReservationService reservationService)
        {
            _reservationService = reservationService;
            _searchService = new SearchPanel();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Results(SearchViewModel vm)
        {
            var reservation = _reservationService.GetReservation(vm.City, vm.StartDate, vm.EndDate, vm.PeopleAmount);
            var items = new List<Reservation>();
            items.Add(reservation);
            return View(items);
        }
    }
}
