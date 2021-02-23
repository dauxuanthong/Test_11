using CMS_Test_12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Test_12.ViewModels
{
	public class ApplicationUserCoordinatorViewModel
	{
		public MarketingCoordinator Coordinator { get; set; }

		public IEnumerable<ApplicationUser> Coordinators { get; set; }
		public IEnumerable<MarketingCoordinator> MarketingCoordinators { get; set; }

	}
}