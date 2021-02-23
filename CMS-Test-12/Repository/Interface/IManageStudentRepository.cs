using CMS_Test_12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Test_12.Repository.Interface
{
	public interface IManageStudentRepository
	{
		IEnumerable<ManageStudents> GetAllStudent();
		void CreateStudentAccount(ManageStudents manageStudents, string Id);
	}
}
