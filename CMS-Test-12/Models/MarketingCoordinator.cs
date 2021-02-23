using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS_Test_12.Models
{
	public class MarketingCoordinator
	{
		public int Id { get; set; }
		public string Name { get; set; }

		[Required]
		public string CoordinatorId { get; set; }
		public ApplicationUser Coordinator { get; set; }
	}
}