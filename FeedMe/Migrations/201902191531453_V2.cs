namespace FeedMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RestaurantsObjs", "urlThumbnail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RestaurantsObjs", "urlThumbnail");
        }
    }
}
