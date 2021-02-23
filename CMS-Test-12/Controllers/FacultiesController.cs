using CMS_Test_12.Models;
using CMS_Test_12.Repository;
using CMS_Test_12.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS_Test_12.Controllers
{
    public class FacultiesController : Controller
    {
		private IFacultyRepository _facultyRepository;

		public FacultiesController()
		{
			_facultyRepository = new FacultyRepository(new ApplicationDbContext());

		}

		public FacultiesController(IFacultyRepository facultiesRepository)
		{
			_facultyRepository = facultiesRepository;
		}


		// GET: Faculties
		[HttpGet]
		public ActionResult Index(string searchString)
		{
			if (!String.IsNullOrEmpty(searchString))
			{
				return View(_facultyRepository.SearchFaculty(searchString).ToList());
			}
			return View(_facultyRepository.GetAllFaculties().ToList());
		}

		//CREATE: Faculties
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}


		[HttpPost]
		public ActionResult Create(Faculty faculty)
		{
			if (!ModelState.IsValid)
			{
				return View("~/Views/ErrorValidations/Null.cshtml");
			}

			if (_facultyRepository.CheckExistFaculty(faculty.Name))
			{
				return View("~/Views/ErrorValidations/Exist.cshtml");
			}

			_facultyRepository.CreateFaculty(faculty);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Delete(int Id)
		{
			_facultyRepository.DeleteFaculty(Id);

			return RedirectToAction("Index");
		}
	}
}