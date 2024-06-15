using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Scripting;
using HotelHero.UserPanel;
using Newtonsoft.Json;
using HotelHero.WebMVC.Services;
using HotelHero.WebMVC.Models;

namespace HotelHero.WebMVC.Controllers
{
    public class CustomerPanelController : Controller
    {
        private readonly CustomerDataService _customerDataService = new CustomerDataService();
        private readonly string _customerEmail = UserContext.GetUser()?.Email;

        // GET: CustomerPanelController
        public ActionResult CustomerPanel()
        {
            return View();
        }
        public ActionResult CustomerData()
        {
            var customerData = _customerDataService.GetCustomerData(_customerEmail);
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
            data.Email = _customerEmail;
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
            return View();
        }
    }
}
