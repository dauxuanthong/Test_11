using CMS_Test_12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Test_12.Repository.Interface
{
	public interface ICoordinatorToFacultyRepository
	{
		IEnumerable<CoordinatorToFaculty> GetAllCoordinatorInFaculty();
		IEnumerable<MarketingCoordinator> GetAllCoordinator();
		IEnumerable<Faculty> GetAllFaculty();

		void CreateCoordinatorInFaculty(CoordinatorToFaculty coordinatorInFaculty);
		void DeleleCoordinatorInFaculty(int Id);
		bool CheckExistCoordinator(int CoordinatorId);
		bool CheckExistFaculty(int FacultyId);
	}
}
