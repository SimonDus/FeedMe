using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FeedMe.Models
{
    public class FeedMeContext : DbContext
    {

        public DbSet<CuisineTypeObj> CuisineTypes { get; set; }

        public DbSet<DishesObj> Dishes { get; set; }

        public DbSet<ImagesObj> Images { get; set; }

        public DbSet<RestaurantsObj> Restaurants { get; set; }

        public DbSet<UserObj> Users { get; set; }

        public DbSet<FavoritesObj> Favorites { get; set; }

        public DbSet<RatingsObj> Ratings { get; set; }

        public DbSet<ReviewsObj> Reviews { get; set; }

    }
}