namespace FeedMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavoritesObjs",
                c => new
                    {
                        FavoriteId = c.Int(nullable: false, identity: true),
                        RestaurantId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FavoriteId);
            
            CreateTable(
                "dbo.RatingsObjs",
                c => new
                    {
                        RatinId = c.Int(nullable: false, identity: true),
                        RestaurantI = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Note = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RatinId);
            
            CreateTable(
                "dbo.ReviewsObjs",
                c => new
                    {
                        ReviewsId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewsId);
            
            AddColumn("dbo.UserObjs", "Password", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserObjs", "Password");
            DropTable("dbo.ReviewsObjs");
            DropTable("dbo.RatingsObjs");
            DropTable("dbo.FavoritesObjs");
        }
    }
}
