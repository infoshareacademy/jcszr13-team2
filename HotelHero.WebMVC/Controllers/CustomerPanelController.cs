using Microsoft.AspNetCore.Mvc;
using HotelHero.WebMVC.Interface;
using HotelHero.HotelsDatabase;
using HotelHero.WebMVC.Models;
using Hotel = HotelHero.WebMVC.Models.Hotel;

namespace HotelHero.WebMVC.Controllers
{
    public class CustomerPanelController : Controller
    {
        private readonly IHotelService _hotelsRepository;
        private readonly ICustomerDataService _customerDataService;
        private readonly IReservationService _reservationService;
        private readonly IPaymentService _paymentService;

        public CustomerPanelController(IHotelService hotelsRepository, ICustomerDataService customerData, IReservationService reservationService, IPaymentService paymentService)
        {
            _hotelsRepository = hotelsRepository;
            _customerDataService = customerData;
            _reservationService = reservationService;
            _paymentService = paymentService;
        }

        // GET: CustomerPanelController
        public ActionResult CustomerPanel()
        {
            return View();
        }
        public ActionResult CustomerData()
        {
            var customerData = _customerDataService.GetCustomerData(UserContext.loggedUser.UserId);
            return View(customerData);
        }

        // GET: CustomerPanelController/Edit/5
        public ActionResult CustomerDataEdit(int customerUserId)
        {
            var customerData = _customerDataService.GetCustomerData(UserContext.loggedUser.UserId);
            return View(customerData);
        }

        // POST: CustomerPanelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerDataEdit(int customerID, CustomerData data)
        {
            _customerDataService.EditCustomerData(data);
            return RedirectToAction("CustomerData");
        }
        public ActionResult Reservations()
        {
            var model = _customerDataService.GetCustomerData(UserContext.loggedUser.UserId).Reservations;
            if(model == null)
            {
                model = new();
            }
            return View(model);
        }
        public ActionResult CancelReservation(int id)
        {
            _customerDataService.CancelReservation(id);
            return RedirectToAction("Reservations");
        }
        public ActionResult PaymentsHistory()
        {
            var paymentsHistory = _paymentService.GetPaymentHistory();
            var model = paymentsHistory.Where(x => x.UserId == UserContext.loggedUser.UserId).ToList();
            return View(model);
        }
        public ActionResult Favourites()
        {
            List<Hotel> model = new();
            var customerFavourites = _customerDataService.GetCustomerData(UserContext.loggedUser.UserId).Favourites;
            if (customerFavourites != null)
            {
                foreach (var item in customerFavourites)
                {
                    var hotel = _hotelsRepository.GetHotel(item);
                    model.Add(hotel);
                }
            }
            return View(model);
        }
        public ActionResult Unfavourite(int id)
        {
            var customerData = _customerDataService.GetCustomerData(UserContext.loggedUser.UserId);
            customerData.Favourites.Remove(id);
            _customerDataService.EditCustomerData(customerData);
            return RedirectToAction(nameof(Favourites));
        }
        public ActionResult FavouriteDetails(int id)
        {
            var model = _hotelsRepository.GetHotel(id);
            return View(model);
        }
        public ActionResult Wallet()
        {
            var model = _customerDataService.GetCustomerData(UserContext.loggedUser.UserId);
            return View(model);
        }
        public ActionResult AddBalance()
        {
            var data = _customerDataService.GetCustomerData(UserContext.loggedUser.UserId);
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBalance(string amount)
        {
            var customerData = _customerDataService.GetCustomerData(UserContext.loggedUser.UserId);
            var parsed = decimal.TryParse(amount, out var balance);
            if (parsed)
            {
                customerData.Balance += balance;
                _customerDataService.EditCustomerData(customerData);
                return RedirectToAction(nameof(Wallet));
            }
            else
            {
                return RedirectToAction(nameof(AddBalance));
            }
        }
    }
}