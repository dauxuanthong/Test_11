namespace CMS_Test_12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ManageStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StudentId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.StudentId)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ManageStudents", "StudentId", "dbo.AspNetUsers");
            DropIndex("dbo.ManageStudents", new[] { "StudentId" });
            DropTable("dbo.ManageStudents");
        }
    }
}
