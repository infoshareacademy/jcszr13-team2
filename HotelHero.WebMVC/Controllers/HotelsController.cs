using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelHero.HotelsDatabase;

namespace HotelHero.WebMVC.Controllers
{
    public class HotelsController : Controller
    {
        private readonly HotelsRepository _hotelsRepository;

        public HotelsController() 
        { 
            _hotelsRepository = new HotelsRepository();
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

        // GET: HotelsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HotelsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: HotelsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HotelsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: HotelsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HotelsController/Delete/5
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
