namespace FeedMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReviewsObjs", "RestaurantID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReviewsObjs", "RestaurantID");
        }
    }
}
