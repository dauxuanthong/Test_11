using CMS_Test_12.Models;
using CMS_Test_12.Repository.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CMS_Test_12.Repository
{
	public class CoordinatorRepository : ICoordinatorRepository
	{
		private ApplicationDbContext _context;

		public CoordinatorRepository()
		{
			_context = new ApplicationDbContext();
		}
		public CoordinatorRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<MarketingCoordinator> GetAllCoordinator()
		{
			return _context.MarketingCoordinators.Include(m => m.Coordinator).ToList();
		}
		public void CreateCoordinatorAccount(MarketingCoordinator coordinator, string Id)
		{
			var newCoordinatorAccount = new MarketingCoordinator
			{
				CoordinatorId = Id,
				Name = coordinator.Name,
			};
			_context.MarketingCoordinators.Add(newCoordinatorAccount);
			_context.SaveChanges();
		}
	}
}		