using FeedMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeedMe.Common
{
    public static class TransformObject
    {
        
        public static RestaurantsView TransformRestoObjIntoRestoView(RestaurantsObj resto, FeedMeContext context)
        {
            string cuisineTypeName = context.CuisineTypes.Where(x => x.IdCuisine == resto.IdCuisine).First().Name;
            RestaurantsView restoView = new RestaurantsView
            {
                Adress = resto.Adress,
                City = resto.City,
                CuisineType = cuisineTypeName,
                IdRestaurant = resto.IdRestaurant,
                Name = resto.Name,
                Phone = resto.Phone,
                PostalCode = resto.PostalCode,
                Rating = resto.Rating,
                urlThumbnail = resto.urlThumbnail
            };
            return restoView;
        }



    }
}