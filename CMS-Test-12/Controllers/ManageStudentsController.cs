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
	public class ManageStudentsController : Controller
	{
		private IManageStudentRepository _manageStudentRepository;

		public ManageStudentsController()
		{
			_manageStudentRepository = new ManageStudentRepository(new ApplicationDbContext());

		}

		public ManageStudentsController(IManageStudentRepository facultiesRepository)
		{
			_manageStudentRepository = facultiesRepository;
		}

		// GET: ManageStudents
		public ActionResult Index()
		{
			return View(_manageStudentRepository.GetAllStudent());
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(ManageStudents manageStudents)
		{
			var userId = User.Identity.GetUserId();

			_manageStudentRepository.CreateStudentAccount(manageStudents, userId);

			return View();
		}

	}
}