﻿using Microsoft.AspNetCore.Mvc;
using HotelHero.WebMVC.Interface;
using HotelHero.HotelsDatabase;

namespace HotelHero.WebMVC.Controllers
{
    public class CustomerPanelController : Controller
    {
        private readonly IHotelService _hotelsRepository;
        private readonly ICustomerDataService _customerDataService;

        public CustomerPanelController(IHotelService hotelsRepository, ICustomerDataService customerData)
        {
            _hotelsRepository = hotelsRepository;
            _customerDataService = customerData;
        }

        // GET: CustomerPanelController
        public ActionResult CustomerPanel()
        {
            return View();
        }
        public ActionResult CustomerData()
        {
            var customerData = _customerDataService.GetCustomerData();
            return View(customerData);
        }

        // GET: CustomerPanelController/Edit/5
        public ActionResult CustomerDataEdit()
        {
            return View();
        }

        // POST: CustomerPanelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerDataEdit(Models.CustomerData data)
        {
            try
            {
                _customerDataService.Save(data);
                return RedirectToAction(nameof(CustomerData));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Reservations()
        {
            return View();
        }
        public ActionResult StaysHistory()
        {
            return View();
        }
        public ActionResult Favourites()
        {
            var customerData = _customerDataService.GetCustomerData();
            List<Hotel> favourites = new();
            foreach (var item in customerData.Favourites)
            {
                var hotel = _hotelsRepository.GetHotel(item);
                favourites.Add(hotel);

            }
            return View(favourites);
        }
        public ActionResult Unfavourite(int id)
        {
            var customerData = _customerDataService.GetCustomerData();
            customerData.Favourites.Remove(id);
            _customerDataService.Save(customerData);
            return RedirectToAction(nameof(Favourites));
        }
        public ActionResult FavouriteDetails(int id)
        {
            var model = _hotelsRepository.GetHotel(id);
            return View(model);
        }
        public ActionResult Wallet()
        {
            var data = _customerDataService.GetCustomerData();
            return View(data);
        }
        public ActionResult AddBalance()
        {
            var data = _customerDataService.GetCustomerData();
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBalance(float amount)
        {
            var customerData = _customerDataService.GetCustomerData();

            //customerData.Balance += decimal.Parse(amount);
            customerData.Balance += (decimal)amount;
            _customerDataService.Save(customerData);
            return RedirectToAction(nameof(Wallet));
        }
    }
}