namespace FeedMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantsObjs", "City", c => c.String(nullable: false));
            AddColumn("dbo.RestaurantsObjs", "Rating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RestaurantsObjs", "Rating");
            DropColumn("dbo.RestaurantsObjs", "City");
        }
    }
}
