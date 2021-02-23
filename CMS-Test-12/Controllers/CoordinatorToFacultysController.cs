using CMS_Test_12.Models;
using CMS_Test_12.Repository;
using CMS_Test_12.Repository.Interface;
using CMS_Test_12.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS_Test_12.Controllers
{
	public class CoordinatorToFacultysController : Controller
	{
		private ICoordinatorToFacultyRepository _coordinatorToFacultyRepository;

		public CoordinatorToFacultysController()
		{
			_coordinatorToFacultyRepository = new CoordinatorToFacultyRepository(new ApplicationDbContext());

		}

		public CoordinatorToFacultysController(ICoordinatorToFacultyRepository coordinatorRepository)
		{
			_coordinatorToFacultyRepository = coordinatorRepository;
		}

		// GET: CoordinatorToFacultys
		public ActionResult Index()
		{
			return View(_coordinatorToFacultyRepository.GetAllCoordinatorInFaculty());
		}

		[HttpGet]
		public ActionResult Create()
		{
			var faculties = _coordinatorToFacultyRepository.GetAllFaculty();
			var coordinatorInFaculty = _coordinatorToFacultyRepository.GetAllCoordinator();

			var newCoordinatorInfaculty = new CoordinatorInFacultyViewModels
			{
				Faculties = faculties,
				MarketingCoordinators = coordinatorInFaculty
			};

			return View(newCoordinatorInfaculty);
		}

		[HttpPost]
		public ActionResult Create(CoordinatorToFaculty coordinatorToFaculty)
		{
			if (!ModelState.IsValid)
			{
				return View("~/Views/ErrorValidations/Null.cshtml");
			}

			if (_coordinatorToFacultyRepository.CheckExistCoordinator(coordinatorToFaculty.CoordinatorId))
			{
				return View("~/Views/ErrorValidations/Exist.cshtml");
			}

			if (_coordinatorToFacultyRepository.CheckExistFaculty(coordinatorToFaculty.FacultyId))
			{
				return View("~/Views/ErrorValidations/Exist.cshtml");
			}

			_coordinatorToFacultyRepository.CreateCoordinatorInFaculty(coordinatorToFaculty);
			return RedirectToAction("Index");
		}


		[HttpGet]
		public ActionResult Delete(int Id)
		{
			_coordinatorToFacultyRepository.DeleleCoordinatorInFaculty(Id);

			return RedirectToAction("Index");
		}
	}
}