namespace FeedMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RatingsObjs",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        RestaurantId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Note = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RatingId);
            
            DropColumn("dbo.ReviewsObjs", "Like");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReviewsObjs", "Like", c => c.Int(nullable: false));
            DropTable("dbo.RatingsObjs");
        }
    }
}
