using CMS_Test_12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Test_12.ViewModels
{
	public class StudenttoFacultyCoordinatorViewModel
	{
		public StudentToFacultyCoordinator StudentToFacultyCoordinator  { get; set; }
		

		public IEnumerable<ManageStudents> Students { get; set; }
		public IEnumerable<Faculty> Faculties{ get; set; }

		public IEnumerable<CoordinatorToFaculty> CoordinatorToFaculties { get; set; }

	}
}