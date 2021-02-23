namespace CMS_Test_12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAssignment1Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignment1",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CoordinatorToFacultyId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CoordinatorToFaculties", t => t.CoordinatorToFacultyId, cascadeDelete: true)
                .Index(t => t.CoordinatorToFacultyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignment1", "CoordinatorToFacultyId", "dbo.CoordinatorToFaculties");
            DropIndex("dbo.Assignment1", new[] { "CoordinatorToFacultyId" });
            DropTable("dbo.Assignment1");
        }
    }
}
