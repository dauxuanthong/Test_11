namespace CMS_Test_12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAssignmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Desciption = c.String(),
                        StudentToFacultyCoordinatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentToFacultyCoordinators", t => t.StudentToFacultyCoordinatorId, cascadeDelete: true)
                .Index(t => t.StudentToFacultyCoordinatorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignments", "StudentToFacultyCoordinatorId", "dbo.StudentToFacultyCoordinators");
            DropIndex("dbo.Assignments", new[] { "StudentToFacultyCoordinatorId" });
            DropTable("dbo.Assignments");
        }
    }
}
