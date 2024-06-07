using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Scripting;
using HotelHero.UserPanel;
using Newtonsoft.Json;
using HotelHero.WebMVC.Services;

namespace HotelHero.WebMVC.Controllers
{
    public class CustomerPanelController : Controller
    {
        private readonly CustomerDataService _customerDataService = new CustomerDataService();
        private readonly string _customerEmail = "admin";

        // GET: CustomerPanelController
        public ActionResult CustomerPanel()
        {
            return View();
        }public ActionResult CustomerData()
        {
            var customerData = _customerDataService.GetCustomerData(_customerEmail);
            return View(customerData);
        }
        // GET: CustomerPanelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

        // GET: CustomerPanelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerPanelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
