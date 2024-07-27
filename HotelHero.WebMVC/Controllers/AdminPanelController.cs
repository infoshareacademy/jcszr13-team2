using HotelHero.ReservationsDatabase;
using HotelHero.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using HotelHero.WebMVC.Interface;
using HotelHero.HotelsDatabase;
using Newtonsoft.Json;

namespace HotelHero.WebMVC.Controllers
{
	public class AdminPanelController : Controller
	{
		private readonly IFileOperationService _fileOperationService;
		private readonly IAdminService _adminService;
		public AdminPanelController(IFileOperationService fileOperationService, IAdminService adminService)
		{
			_fileOperationService = fileOperationService;
			_adminService = adminService;
		}
		// GET: AdminPanelController
		public ActionResult Index()
		{
			return View();
		}

		// GET: AdminPanelController/Users
		public ActionResult Users()
		{
			var model = _fileOperationService.GetUsers();
			return View(model);
		}
		public ActionResult CreateUser()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult CreateUser(User user)
		{
			_fileOperationService.CreateUser(user.Email, user.Password);
			return RedirectToAction("Users");
		}

		// GET: AdminPanelController/Edit
		public ActionResult EditUser(int id)
		{
			var model = _fileOperationService.GetUser(id);
			return View(model);
		}

		// POST: AdminPanelController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditUser(int id, User user)
		{
			_fileOperationService.EditUser(id, user);
			return RedirectToAction("Users");
		}

		// GET: AdminPanelController/Delete
		public ActionResult DeleteUser(int id)
		{
			var model = _fileOperationService.GetUser(id);
			return View(model);
		}

		// POST: AdminPanelController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteUser(int id, IFormCollection collection)
		{
			_fileOperationService.DeleteUser(id);
			return RedirectToAction("Users");
		}

		public ActionResult AdditionalServicesList()
		{
			var model = _adminService.GetAdditionalServicesList();
			return View(model);
		}


	}
}

