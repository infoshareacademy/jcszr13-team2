using Microsoft.AspNetCore.Mvc;
using HotelHero.WebMVC.Interface;
using HotelHero.WebMVC.Models;

namespace HotelHero.WebMVC.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ICustomerDataService _customerDataService;
        private readonly IReservationService _reservationService;
        private readonly IPaymentService _paymentService;
        private readonly IAdminService _adminService;
        public PaymentController(ICustomerDataService customerDataService, IReservationService reservationService, IPaymentService paymentService, IAdminService adminService)
        {
            _customerDataService = customerDataService;
            _reservationService = reservationService;
            _paymentService = paymentService;
            _adminService = adminService;
        }
        // GET: PaymentController
        public ActionResult Index(int id)
        {
            var model = _paymentService.GetPayment(id);
            return View(model);
        }
        public ActionResult PaymentAdditionalServices(int id)
        {
            var model = _paymentService.GetPayment(id);
			model.AdditionalServices = _adminService.GetAdditionalServicesList();
            return View(model);
        }
        [HttpPost]
		public ActionResult PaymentAdditionalServices(int id, Payment paymentAdditionalServices)
		{
			var payment = _paymentService.GetPayment(id);
			payment.AdditionalServices = paymentAdditionalServices.AdditionalServices;
            _paymentService.UpdatePayment(payment);
			return RedirectToAction("PaymentSummary", new RouteValueDictionary(new { controller = "Payment", action = "PaymentSummary", Id = id }));
		}
		public ActionResult PaymentSummary(int id)
        {
			var payment = _paymentService.GetPayment(id);
			return View(payment);
        }
        public ActionResult CancelPayment(int id)
        {
			var payment = _paymentService.GetPayment(id);
            var reservation = _reservationService.GetReservationById(payment.Reservation.Id);

            reservation.CancelReservation();
			_customerDataService.CancelReservation(reservation.Id);
            _paymentService.CancelPayment(id);
            return RedirectToAction("Index", "Search");
        }
        public ActionResult ConfirmPayment(int id)
        {
			var payment = _paymentService.GetPayment(id);
			var customerData = _customerDataService.GetCustomerData(UserContext.loggedUser.UserId);
            var model = _reservationService.GetReservationById(payment.Reservation.Id);
            var totalCost = payment.GetTotalCost();
            _paymentService.UpdatePayment(payment);

            customerData.Balance -= totalCost;
            model.PayReservation();
            _customerDataService.PayReservation(model);
            _customerDataService.EditCustomerData(customerData);

            return RedirectToAction("Reservations", "CustomerPanel");
        }
        public ActionResult ToWallet()
        {
            return RedirectToAction("Wallet", "CustomerPanel");
        }
    }
}



