using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Test_12.Models
{
	public class CoordinatorToFaculty
	{
		public int Id { get; set; }
		
		public int CoordinatorId { get; set; }
		public MarketingCoordinator Coordinator { get; set; }

		public int FacultyId { get; set; }
		public Faculty Faculty { get; set; }
	}
}