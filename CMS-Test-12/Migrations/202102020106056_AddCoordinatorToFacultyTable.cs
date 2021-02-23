namespace CMS_Test_12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCoordinatorToFacultyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoordinatorToFaculties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoordinatorId = c.Int(nullable: false),
                        FacultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MarketingCoordinators", t => t.CoordinatorId, cascadeDelete: true)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .Index(t => t.CoordinatorId)
                .Index(t => t.FacultyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CoordinatorToFaculties", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.CoordinatorToFaculties", "CoordinatorId", "dbo.MarketingCoordinators");
            DropIndex("dbo.CoordinatorToFaculties", new[] { "FacultyId" });
            DropIndex("dbo.CoordinatorToFaculties", new[] { "CoordinatorId" });
            DropTable("dbo.CoordinatorToFaculties");
        }
    }
}
