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

        public static RestaurantsViewDetails TransformRestoObjIntoRestoViewDetails(RestaurantsObj resto, FeedMeContext context)
        {
            RestaurantsView restoV = TransformRestoObjIntoRestoView(resto, context);
            List<ImagesObj> imgList = context.Images.Where(x => x.IdRestaurant == resto.IdRestaurant).ToList();
            List<DishesObj> dishesList = context.Dishes.Where(x => x.IdRestaurant == resto.IdRestaurant).ToList();
            RestaurantsViewDetails restoD = new RestaurantsViewDetails
            {
                Adress = restoV.Adress,
                City = restoV.City,
                CuisineType = restoV.CuisineType,
                IdRestaurant = restoV.IdRestaurant,
                Name = restoV.Name,
                Phone = restoV.Phone,
                PostalCode = restoV.PostalCode,
                Rating = restoV.Rating,
                urlThumbnail = restoV.urlThumbnail,
                Images = imgList,
                Dishes = dishesList
            };
            return restoD;
        }

        public static RestaurantsModify TransformRestoObjIntoRestoModify(RestaurantsObj resto, FeedMeContext context)
        {
            string cuisineTypeName = context.CuisineTypes.Where(x => x.IdCuisine == resto.IdCuisine).First().Name;
            RestaurantsModify restoMod = new RestaurantsModify
            {
                Adress = resto.Adress,
                City = resto.City,
                CuisineType = cuisineTypeName,
                IdRestaurant = resto.IdRestaurant,
                Name = resto.Name,
                Phone = resto.Phone,
                PostalCode = resto.PostalCode,
                urlThumbnail = resto.urlThumbnail
            };
            return restoMod;
        }

        public static RestaurantsObj TransformRestoModifyIntoRestoObj(RestaurantsModify restoMod, FeedMeContext context)
        {
            int cuisineTypeId = context.CuisineTypes.Where(x => x.Name == restoMod.CuisineType).First().IdCuisine;
            RestaurantsObj restoOld = context.Restaurants.Where(x => x.IdRestaurant == restoMod.IdRestaurant).First();
            RestaurantsObj resto = new RestaurantsObj
            {
                Adress = restoMod.Adress,
                City = restoMod.City,
                IdCuisine = cuisineTypeId,
                IdRestaurant = restoMod.IdRestaurant,
                Name = restoMod.Name,
                Phone = restoMod.Phone,
                PostalCode = restoMod.PostalCode,
                Rating = restoOld.Rating,
                urlThumbnail = restoMod.urlThumbnail
            };
            return resto;
        }

    }
}