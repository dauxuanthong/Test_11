using CMS_Test_12.Models;
using CMS_Test_12.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CMS_Test_12.Repository
{
	public class CoordinatorToFacultyRepository : ICoordinatorToFacultyRepository
	{
		private ApplicationDbContext _context;

		public CoordinatorToFacultyRepository()
		{
			_context = new ApplicationDbContext();
		}
		public CoordinatorToFacultyRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<CoordinatorToFaculty> GetAllCoordinatorInFaculty()
		{
			return _context.CoordinatorToFacultys.Include(m => m.Coordinator).Include(m => m.Faculty).ToList();
		}

		public IEnumerable<Faculty> GetAllFaculty()
		{
			return _context.Faculties.ToList();
		}

		public IEnumerable<MarketingCoordinator> GetAllCoordinator()
		{
			return _context.MarketingCoordinators.ToList();
		}

		public void CreateCoordinatorInFaculty(CoordinatorToFaculty coordinatorToFaculty)
		{
			var newCoordinatorInFaculty = new CoordinatorToFaculty
			{
				CoordinatorId = coordinatorToFaculty.CoordinatorId,
				FacultyId = coordinatorToFaculty.FacultyId
			};

			_context.CoordinatorToFacultys.Add(newCoordinatorInFaculty);
			_context.SaveChanges();
		}

		public void DeleleCoordinatorInFaculty(int Id)
		{
			var coordinatorinfaculty = _context.CoordinatorToFacultys.SingleOrDefault(m => m.Id == Id);

			_context.CoordinatorToFacultys.Remove(coordinatorinfaculty);
			_context.SaveChanges();
		}

		public bool CheckExistCoordinator(int CoordinatorId)
		{
			bool CoordinatorIsExist = _context.CoordinatorToFacultys.Any(m => m.CoordinatorId == CoordinatorId);

			return CoordinatorIsExist;
		}

		public bool CheckExistFaculty(int FacultyId)
		{
			bool FacultyIsExist = _context.CoordinatorToFacultys.Any(m => m.FacultyId == FacultyId);

			return FacultyIsExist;
		}
	}
}