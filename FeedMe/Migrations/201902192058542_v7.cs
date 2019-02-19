namespace FeedMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DishesObjs", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DishesObjs", "Price", c => c.Int(nullable: false));
        }
    }
}
