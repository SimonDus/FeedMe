namespace FeedMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DishesObjs", "IdRestaurant", c => c.Int(nullable: false));
            DropColumn("dbo.DishesObjs", "IdMenu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DishesObjs", "IdMenu", c => c.Int(nullable: false));
            DropColumn("dbo.DishesObjs", "IdRestaurant");
        }
    }
}
