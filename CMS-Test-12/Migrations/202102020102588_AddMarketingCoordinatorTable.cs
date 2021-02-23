namespace CMS_Test_12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMarketingCoordinatorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MarketingCoordinators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        CoordinatorId = c.String(nullable: false),
                        Coordinator_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MarketingCoordinators", t => t.Coordinator_Id)
                .Index(t => t.Coordinator_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MarketingCoordinators", "Coordinator_Id", "dbo.MarketingCoordinators");
            DropIndex("dbo.MarketingCoordinators", new[] { "Coordinator_Id" });
            DropTable("dbo.MarketingCoordinators");
        }
    }
}
