namespace CMS_Test_12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMarketingCoordinatorTable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MarketingCoordinators", "Coordinator_Id", "dbo.MarketingCoordinators");
            DropIndex("dbo.MarketingCoordinators", new[] { "Coordinator_Id" });
            DropColumn("dbo.MarketingCoordinators", "CoordinatorId");
            RenameColumn(table: "dbo.MarketingCoordinators", name: "Coordinator_Id", newName: "CoordinatorId");
            AlterColumn("dbo.MarketingCoordinators", "CoordinatorId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.MarketingCoordinators", "CoordinatorId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.MarketingCoordinators", "CoordinatorId");
            AddForeignKey("dbo.MarketingCoordinators", "CoordinatorId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MarketingCoordinators", "CoordinatorId", "dbo.AspNetUsers");
            DropIndex("dbo.MarketingCoordinators", new[] { "CoordinatorId" });
            AlterColumn("dbo.MarketingCoordinators", "CoordinatorId", c => c.Int());
            AlterColumn("dbo.MarketingCoordinators", "CoordinatorId", c => c.String(nullable: false));
            RenameColumn(table: "dbo.MarketingCoordinators", name: "CoordinatorId", newName: "Coordinator_Id");
            AddColumn("dbo.MarketingCoordinators", "CoordinatorId", c => c.String(nullable: false));
            CreateIndex("dbo.MarketingCoordinators", "Coordinator_Id");
            AddForeignKey("dbo.MarketingCoordinators", "Coordinator_Id", "dbo.MarketingCoordinators", "Id");
        }
    }
}
