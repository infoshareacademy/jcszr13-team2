using HotelHero.WebMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelHero.WebMVC.Controllers
{
    public class SearchController : Controller
    {
        private readonly SearchPanel _searchService;

        public SearchController()
        {
            _searchService = new SearchPanel();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Results(string query)
        {
            List<string> results = _searchService.Search(query);
            return View(results);
        }
    }
}
