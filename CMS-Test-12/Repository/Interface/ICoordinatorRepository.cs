using CMS_Test_12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Test_12.Repository.Interface
{
	public interface ICoordinatorRepository
	{
		IEnumerable<MarketingCoordinator> GetAllCoordinator();

		void CreateCoordinatorAccount(MarketingCoordinator coordinator, string Id);
/*		void DeleteCoordinatorInformation(int Id);
		bool CheckExsistCoordinatorInformation(int Id);*/
	}
}
