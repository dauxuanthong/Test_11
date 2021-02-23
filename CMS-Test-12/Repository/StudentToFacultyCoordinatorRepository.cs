using CMS_Test_12.Models;
using CMS_Test_12.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CMS_Test_12.Repository
{
	public class StudentToFacultyCoordinatorRepository : IStudentToFacultyCoordinatorRepository
	{
		private ApplicationDbContext _context;

		public StudentToFacultyCoordinatorRepository()
		{
			_context = new ApplicationDbContext();
		}

		public StudentToFacultyCoordinatorRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<StudentToFacultyCoordinator> GetAllStudentsInFaculty()
		{
			return _context.StudentToFacultyCoordinators.Include(m => m.ManageStudent).Include(m => m.CoordinatorToFaculty).ToList();
		}

		public IEnumerable<ManageStudents> GetAllStudents()
		{
			return _context.ManageStudents.Include(m => m.Student).ToList();
		}

		public IEnumerable<CoordinatorToFaculty> GetAllCoordinatorToFaculties()
		{
			return _context.CoordinatorToFacultys.ToList();
		}

		public void CreateStudentToFacultyCoordinator(StudentToFacultyCoordinator studentToFacultyCoordinator)
		{
			var newStudentToFacultyCoordinator = new StudentToFacultyCoordinator
			{
				ManageStudentId = studentToFacultyCoordinator.ManageStudentId,
				CoordinatorToFacultyId = studentToFacultyCoordinator.CoordinatorToFacultyId
			};

			_context.StudentToFacultyCoordinators.Add(newStudentToFacultyCoordinator);
			_context.SaveChanges();
		}

		public void DeleteStudentInFaculty(int Id)
		{
			var StudentInFaculty = _context.StudentToFacultyCoordinators.SingleOrDefault(m => m.Id == Id);

			_context.StudentToFacultyCoordinators.Remove(StudentInFaculty);
			_context.SaveChanges();
		}

		public bool CheckExistStudentInFacultyCoordinator(int ManageStudentId)
		{
			var IsStudentInFaculty = _context.StudentToFacultyCoordinators.Any(m => m.ManageStudentId == ManageStudentId);

			return IsStudentInFaculty;
		}

		public bool CheckExistCoordinatorInFaculty(int CoordinatorToFacultyId)
		{
			var IsCoordinatorInFaculty = _context.StudentToFacultyCoordinators.Any(m => m.CoordinatorToFacultyId == CoordinatorToFacultyId);

			return IsCoordinatorInFaculty;
		}
	}
}