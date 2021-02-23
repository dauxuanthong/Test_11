using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Test_12.Models
{
	public class ManageStudents
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public string StudentId { get; set; }
		public ApplicationUser Student { get; set; }
	}
}