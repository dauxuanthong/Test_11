namespace CMS_Test_12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentToFacultyCoordinatorTable1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.StudentToFacultyCoordinators", name: "ManageStudent_Id", newName: "ManageStudents_Id");
            RenameIndex(table: "dbo.StudentToFacultyCoordinators", name: "IX_ManageStudent_Id", newName: "IX_ManageStudents_Id");
            AddColumn("dbo.StudentToFacultyCoordinators", "ManageStudentId", c => c.Int(nullable: false));
            DropColumn("dbo.StudentToFacultyCoordinators", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentToFacultyCoordinators", "StudentId", c => c.Int(nullable: false));
            DropColumn("dbo.StudentToFacultyCoordinators", "ManageStudentId");
            RenameIndex(table: "dbo.StudentToFacultyCoordinators", name: "IX_ManageStudents_Id", newName: "IX_ManageStudent_Id");
            RenameColumn(table: "dbo.StudentToFacultyCoordinators", name: "ManageStudents_Id", newName: "ManageStudent_Id");
        }
    }
}
