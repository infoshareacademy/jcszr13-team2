using HotelHero.UserPanel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelHero.WebMVC.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET: AdminPanelController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminPanelController
        public ActionResult Users()
        {
            FileOperations fileOperations = new FileOperations();
            var model = fileOperations.DeserializeFile();
            return View(model);
        }
    }
}
