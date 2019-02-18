namespace FeedMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CuisineTypeObjs",
                c => new
                    {
                        IdCuisine = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdCuisine);
            
            CreateTable(
                "dbo.DishesObjs",
                c => new
                    {
                        IdDishes = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        IdMenu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDishes);
            
            CreateTable(
                "dbo.ImagesObjs",
                c => new
                    {
                        IdImage = c.Int(nullable: false, identity: true),
                        Url = c.String(nullable: false),
                        IdRestaurant = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdImage);
            
            CreateTable(
                "dbo.MenusObjs",
                c => new
                    {
                        IdMenu = c.Int(nullable: false, identity: true),
                        IdRestaurant = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdMenu);
            
            CreateTable(
                "dbo.RestaurantsObjs",
                c => new
                    {
                        IdRestaurant = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Adress = c.String(nullable: false),
                        PostalCode = c.Int(nullable: false),
                        Phone = c.String(nullable: false),
                        IdCuisine = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdRestaurant);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RestaurantsObjs");
            DropTable("dbo.MenusObjs");
            DropTable("dbo.ImagesObjs");
            DropTable("dbo.DishesObjs");
            DropTable("dbo.CuisineTypeObjs");
        }
    }
}
