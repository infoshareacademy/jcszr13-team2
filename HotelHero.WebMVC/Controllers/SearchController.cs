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

        public ActionResult MakeReservation(int id)
        {
            var model = _reservationService.GetReservationById(id);
            model.UpdateReservationStatus(ReservationStatus.Reserved);
            UserContext.MakeReservation(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
