using CMS_Test_12.Models;
using CMS_Test_12.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Test_12.Repository
{
	public class FacultyRepository : IFacultyRepository
	{
		private ApplicationDbContext _context;

		public FacultyRepository()
		{
			_context = new ApplicationDbContext();
		}

		public FacultyRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Faculty> GetAllFaculties()
		{
			return _context.Faculties;
		}

		public void CreateFaculty(Faculty faculty)
		{
			var newFaculty = new Faculty
			{
				Name = faculty.Name,
				Description = faculty.Description
			};
			_context.Faculties.Add(newFaculty);
			_context.SaveChanges();
		}

		public IEnumerable<Faculty> SearchFaculty(string searchString)
		{
			IEnumerable<Faculty> faculties = GetAllFaculties();

			return faculties.Where(t => t.Name.Contains(searchString));
		}

		public bool CheckExistFaculty(string stringFaculty)
		{
			return _context.Faculties.Any(f => f.Name.Contains(stringFaculty));
		}

		public void DeleteFaculty(int Id)
		{
			var facultyInDb = _context.Faculties.SingleOrDefault(f => f.Id == Id);
			_context.Faculties.Remove(facultyInDb);
			_context.SaveChanges();
		}
	}
}