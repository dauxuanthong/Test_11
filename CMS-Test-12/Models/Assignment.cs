using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Test_12.Models
{
	public class Assignment
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Desciption { get; set; }

		public int StudentToFacultyCoordinatorId { get; set; }
		public StudentToFacultyCoordinator StudentToFacultyCoordinator { get; set; }

	}
}