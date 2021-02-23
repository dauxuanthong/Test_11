using CMS_Test_12.Models;
using CMS_Test_12.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CMS_Test_12.Repository
{
	public class ManageStudentRepository : IManageStudentRepository
	{
		private ApplicationDbContext _context;

		public ManageStudentRepository()
		{
			_context = new ApplicationDbContext();
		}
		public ManageStudentRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<ManageStudents> GetAllStudent()
		{
			return _context.ManageStudents.Include(m => m.Student).ToList(); 
		}

		public void CreateStudentAccount(ManageStudents manageStudents, string Id)
		{
			var newStudentAccount = new ManageStudents
			{
				StudentId = Id,
				Name = manageStudents.Name
			};
			_context.ManageStudents.Add(newStudentAccount);
			_context.SaveChanges();
		}
	}
}