namespace FeedMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DishesObjs", "Pde", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DishesObjs", "Pde");
        }
    }
}
