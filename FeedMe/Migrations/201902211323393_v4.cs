namespace FeedMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.RatingsObjs");
        }
        
        public override void Down()
        {
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
            
        }
    }
}
