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
	public class StudentToFacultyCoordinatorsController : Controller
	{
		private IStudentToFacultyCoordinatorRepository _studentToFacultyCoordinatorRepository;

		public StudentToFacultyCoordinatorsController()
		{
			_studentToFacultyCoordinatorRepository = new StudentToFacultyCoordinatorRepository(new ApplicationDbContext());

		}
		public ActionResult Index()
		{
			return View(_studentToFacultyCoordinatorRepository.GetAllStudentsInFaculty());
		}

		[HttpGet]
		public ActionResult Create()
		{
			var coordinatorinfacultys = _studentToFacultyCoordinatorRepository.GetAllCoordinatorToFaculties();
			var students = _studentToFacultyCoordinatorRepository.GetAllStudents();

			var studentFacultyCoordinator = new StudenttoFacultyCoordinatorViewModel
			{
				Students = students,
				CoordinatorToFaculties = coordinatorinfacultys,
			};

			return View(studentFacultyCoordinator);
		}

		[HttpPost]
		public ActionResult Create(StudentToFacultyCoordinator studentToFacultyCoordinator)
		{
			if(!ModelState.IsValid)
			{
				return View("~/Views/ErrorValidations/Null.cshtml");
			}

			if(_studentToFacultyCoordinatorRepository.CheckExistCoordinatorInFaculty(studentToFacultyCoordinator.CoordinatorToFacultyId))
			{
				return View("~/Views/ErrorValidations/Exist.cshtml");
			}

			if (_studentToFacultyCoordinatorRepository.CheckExistStudentInFacultyCoordinator(studentToFacultyCoordinator.ManageStudentId))
			{
				return View("~/Views/ErrorValidations/Exist.cshtml");
			}

			_studentToFacultyCoordinatorRepository.CreateStudentToFacultyCoordinator(studentToFacultyCoordinator);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Delete(int Id)
		{
			_studentToFacultyCoordinatorRepository.DeleteStudentInFaculty(Id);

			return RedirectToAction("Index");
		}
	}
}