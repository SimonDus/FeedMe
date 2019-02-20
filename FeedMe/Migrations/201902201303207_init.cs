namespace FeedMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
                        Price = c.Double(nullable: false),
                        IdRestaurant = c.Int(nullable: false),
                        Pde = c.String(maxLength: 1),
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
                "dbo.RestaurantsObjs",
                c => new
                    {
                        IdRestaurant = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Adress = c.String(nullable: false),
                        PostalCode = c.Int(nullable: false),
                        Phone = c.String(nullable: false),
                        IdCuisine = c.Int(nullable: false),
                        urlThumbnail = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdRestaurant);
            
            CreateTable(
                "dbo.UserObjs",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Role = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Firstname = c.String(nullable: false),
                        MailAdress = c.String(nullable: false),
                        Birthdate = c.String(),
                        Gender = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserObjs");
            DropTable("dbo.RestaurantsObjs");
            DropTable("dbo.ImagesObjs");
            DropTable("dbo.DishesObjs");
            DropTable("dbo.CuisineTypeObjs");
        }
    }
}
