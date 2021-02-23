namespace CMS_Test_12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPostTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        PostName = c.String(),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                        Image = c.Binary(),
                        UrlImage = c.String(),
                        StudentToFacultyCoordinatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.StudentToFacultyCoordinators", t => t.StudentToFacultyCoordinatorId, cascadeDelete: true)
                .Index(t => t.StudentToFacultyCoordinatorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "StudentToFacultyCoordinatorId", "dbo.StudentToFacultyCoordinators");
            DropIndex("dbo.Posts", new[] { "StudentToFacultyCoordinatorId" });
            DropTable("dbo.Posts");
        }
    }
}
