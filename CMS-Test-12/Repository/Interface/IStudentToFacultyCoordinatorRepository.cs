using CMS_Test_12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Test_12.Repository.Interface
{
	public interface IStudentToFacultyCoordinatorRepository
	{
		IEnumerable<StudentToFacultyCoordinator> GetAllStudentsInFaculty();
		IEnumerable<ManageStudents> GetAllStudents();
		IEnumerable<CoordinatorToFaculty> GetAllCoordinatorToFaculties();
		void CreateStudentToFacultyCoordinator(StudentToFacultyCoordinator studentToFacultyCoordinator);
		bool CheckExistStudentInFacultyCoordinator(int ManageStudentId);
		bool CheckExistCoordinatorInFaculty(int CoordinatorToFacultyId);
		void DeleteStudentInFaculty(int Id);
	}
}
