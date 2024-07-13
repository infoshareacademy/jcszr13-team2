using HotelHero.HotelsDatabase;
using HotelHero.ReservationsDatabase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;
using System.Net;
using System;
using HotelHero.WebMVC.Interface;
using HotelHero.ReservationsDatabase.Enums;
using HotelHero.WebMVC.Models;

namespace HotelHero.WebMVC.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ICustomerDataService _customerDataService;
        private readonly IReservationService _reservationService;
        private readonly IPaymentService _paymentService;
        public PaymentController(ICustomerDataService customerDataService, IReservationService reservationService, IPaymentService paymentService)
        {
            _customerDataService = customerDataService;
            _reservationService = reservationService;
            _paymentService = paymentService;
        }
        // GET: PaymentController
        public ActionResult Index()
        {
            var model = _paymentService.GetReservation();
            return View(model);
        }

        public ActionResult Pay(int id)
        {
            var model = _reservationService.GetReservationById(id);
            return View(model);
        }
        public ActionResult Cancel()
        {
            var model = _paymentService.GetReservation();
            UserContext.CancelReservation(model);
            return RedirectToAction("Index", "Search");
        }
        public ActionResult PayConfirm(int id)
        {
            var customerData = _customerDataService.GetCustomerData();
            var model = _reservationService.GetReservationById(id);
            var reservationCost = model.GetReservationCost();
            customerData.Balance -= reservationCost;
            _customerDataService.Save(customerData);
            model.UpdateReservationStatus(ReservationStatus.Paid);
            return RedirectToAction("Reservations", "CustomerPanel");
        }
        public ActionResult ToWallet()
        {
            return RedirectToAction("Wallet", "CustomerPanel");
        }
    }
}


