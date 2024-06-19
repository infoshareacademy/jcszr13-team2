using Microsoft.AspNetCore.Mvc;
using HotelHero.HotelsDatabase;
using HotelHero.WebMVC.Interface;
using HotelHero.WebMVC.Models;

namespace HotelHero.WebMVC.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotelService _hotelsRepository;
        private readonly ICustomerDataService _customerDataService;

        public HotelsController(IHotelService hotelsRepository, ICustomerDataService customerData)
        {
            _hotelsRepository = hotelsRepository;
            _customerDataService = customerData;
        }


        public ActionResult Index()
        {
            var model = _hotelsRepository.GetHotels();
            return View(model);
        }

        // GET: HotelsController/Details/5
        public ActionResult Details(int id)
        {
            var model = _hotelsRepository.GetHotel(id);
            return View(model);
        }

        public ActionResult Favourite(int id)
        {
            try
            {
                var customerData = _customerDataService.GetCustomerData();
                if (customerData.Favourites == null)
                {
                    customerData.Favourites = new List<int> { };
                }
                customerData.Favourites.Add(id);
                _customerDataService.Save(customerData);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Unfavourite(int id)
        {
            try
            {
                var customerData = _customerDataService.GetCustomerData();
                if (customerData.Favourites == null)
                {
                    customerData.Favourites = new List<int> { };
                }
                customerData.Favourites.Remove(id);
                _customerDataService.Save(customerData);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: HotelsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HotelsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hotel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                _hotelsRepository.Create(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HotelsController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _hotelsRepository.GetHotel(id);
            return View(model);
        }

        // POST: HotelsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Hotel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                _hotelsRepository.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HotelsController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _hotelsRepository.GetHotel(id);
            return View(model);
        }

        // POST: HotelsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _hotelsRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
