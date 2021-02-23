using CMS_Test_12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Test_12.ViewModels
{
	public class CoordinatorInFacultyViewModels
	{
		public CoordinatorToFaculty CoordinatorToFaculty{ get; set; }
		public IEnumerable<MarketingCoordinator> MarketingCoordinators { get; set; }
		public IEnumerable<Faculty> Faculties { get; set; }
	}
}