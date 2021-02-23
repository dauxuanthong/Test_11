using CMS_Test_12.Models;
using CMS_Test_12.Repository;
using CMS_Test_12.Repository.Interface;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS_Test_12.Controllers
{
	public class CoordinatorsController : Controller
	{
		private ICoordinatorRepository _coordinatorRepository;

		public CoordinatorsController()
		{
			_coordinatorRepository = new CoordinatorRepository(new ApplicationDbContext());

		}

		public CoordinatorsController(ICoordinatorRepository coordinatorRepository)
		{
			_coordinatorRepository = coordinatorRepository;
		}


		// GET: Faculties
		[HttpGet]
		public ActionResult Index()
		{
			/*if (!String.IsNullOrEmpty(searchString))
			{
				return View(_coordinatorRepository.SearchFaculty(searchString).ToList());
			}*/
			return View(_coordinatorRepository.GetAllCoordinator().ToList());
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(MarketingCoordinator coordinator)
		{
			var userId = User.Identity.GetUserId();

			_coordinatorRepository.CreateCoordinatorAccount(coordinator, userId);

			return View();
		}
	}
}