using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Test_12.Models
{
	public class StudentToFacultyCoordinator
	{
		public int Id { get; set; }
		public string Description { get; set; }

		public int CoordinatorToFacultyId { get; set; }
		public CoordinatorToFaculty CoordinatorToFaculty { get; set; }

		public int ManageStudentId { get; set; }
		public ManageStudents ManageStudent { get; set; } 
	}
}