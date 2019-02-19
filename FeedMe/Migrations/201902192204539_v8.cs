namespace FeedMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v8 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.MenusObjs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MenusObjs",
                c => new
                    {
                        IdMenu = c.Int(nullable: false, identity: true),
                        IdRestaurant = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdMenu);
            
        }
    }
}
