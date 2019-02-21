using FeedMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeedMe.Common
{
    public static class Tools
    {
        public static void ratingAvg(int id, FeedMeContext context)
        {
            List<RatingsObj> ratingList = context.Ratings.Where(x => x.RestaurantId == id).ToList();
            double result = 0;
            foreach (var item in ratingList)
            {
                result += item.Note;
            }
            result = result / ratingList.Count();
            RestaurantsObj restoMaj = context.Restaurants.Where(x => x.IdRestaurant == id).First();
            restoMaj.Rating = result;
            context.SaveChanges();
        }
    }
}