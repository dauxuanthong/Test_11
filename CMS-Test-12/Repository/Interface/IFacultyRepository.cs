using CMS_Test_12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Test_12.Repository.Interface
{
	public interface IFacultyRepository
	{
		IEnumerable<Faculty> GetAllFaculties();
		void CreateFaculty(Faculty faculty);

		IEnumerable<Faculty> SearchFaculty(string searchString);
		bool CheckExistFaculty(string stringFaculty);

		void DeleteFaculty(int Id);
	}
}
