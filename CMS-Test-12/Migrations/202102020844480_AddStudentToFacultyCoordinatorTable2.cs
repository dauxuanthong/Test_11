namespace CMS_Test_12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentToFacultyCoordinatorTable2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentToFacultyCoordinators", "ManageStudents_Id", "dbo.ManageStudents");
            DropIndex("dbo.StudentToFacultyCoordinators", new[] { "ManageStudents_Id" });
            DropColumn("dbo.StudentToFacultyCoordinators", "ManageStudentId");
            RenameColumn(table: "dbo.StudentToFacultyCoordinators", name: "ManageStudents_Id", newName: "ManageStudentId");
            AlterColumn("dbo.StudentToFacultyCoordinators", "ManageStudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentToFacultyCoordinators", "ManageStudentId");
            AddForeignKey("dbo.StudentToFacultyCoordinators", "ManageStudentId", "dbo.ManageStudents", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentToFacultyCoordinators", "ManageStudentId", "dbo.ManageStudents");
            DropIndex("dbo.StudentToFacultyCoordinators", new[] { "ManageStudentId" });
            AlterColumn("dbo.StudentToFacultyCoordinators", "ManageStudentId", c => c.Int());
            RenameColumn(table: "dbo.StudentToFacultyCoordinators", name: "ManageStudentId", newName: "ManageStudents_Id");
            AddColumn("dbo.StudentToFacultyCoordinators", "ManageStudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentToFacultyCoordinators", "ManageStudents_Id");
            AddForeignKey("dbo.StudentToFacultyCoordinators", "ManageStudents_Id", "dbo.ManageStudents", "Id");
        }
    }
}
