namespace CMS_Test_12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMarketingCoordinatorTable2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MarketingCoordinators", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MarketingCoordinators", "Name", c => c.Int(nullable: false));
        }
    }
}
