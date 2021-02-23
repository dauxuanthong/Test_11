using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS_Test_12.Models
{
	public class Assignment1
	{
		[Key]
		public int ID { get; set; }
		//KF
		public int CoordinatorToFacultyId { get; set; }
		public CoordinatorToFaculty CoordinatorToFaculty { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

	}
}