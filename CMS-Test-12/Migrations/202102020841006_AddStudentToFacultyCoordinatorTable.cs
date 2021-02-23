namespace CMS_Test_12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentToFacultyCoordinatorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentToFacultyCoordinators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CoordinatorToFacultyId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        ManageStudent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CoordinatorToFaculties", t => t.CoordinatorToFacultyId, cascadeDelete: true)
                .ForeignKey("dbo.ManageStudents", t => t.ManageStudent_Id)
                .Index(t => t.CoordinatorToFacultyId)
                .Index(t => t.ManageStudent_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentToFacultyCoordinators", "ManageStudent_Id", "dbo.ManageStudents");
            DropForeignKey("dbo.StudentToFacultyCoordinators", "CoordinatorToFacultyId", "dbo.CoordinatorToFaculties");
            DropIndex("dbo.StudentToFacultyCoordinators", new[] { "ManageStudent_Id" });
            DropIndex("dbo.StudentToFacultyCoordinators", new[] { "CoordinatorToFacultyId" });
            DropTable("dbo.StudentToFacultyCoordinators");
        }
    }
}
