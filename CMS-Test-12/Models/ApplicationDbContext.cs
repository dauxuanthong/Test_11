using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CMS_Test_12.Models
{

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public DbSet<Faculty> Faculties { get; set; }
		public DbSet<MarketingCoordinator> MarketingCoordinators { get; set; }
		public DbSet<CoordinatorToFaculty> CoordinatorToFacultys { get; set; }
		public DbSet<ManageStudents> ManageStudents { get; set; }
		public DbSet<StudentToFacultyCoordinator> StudentToFacultyCoordinators { get; set; }
		public DbSet<Assignment> Assignments { get; set; }
		public DbSet<Assignment1> Assignment1s { get; set; }

		public DbSet<Post> Posts { get; set; }

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}