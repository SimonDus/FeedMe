using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using FeedMe.Common;
using FeedMe.Models;

namespace FeedMe.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "$")]
    public class RestaurantsController : ApiController
    {
        private FeedMeContext db = new FeedMeContext();

        [Route("api/restaurants/getrestaurants")]
        public List<RestaurantsView> GetRestaurants(string name = "", string cuisineType = "")
        {
            List<RestaurantsObj> restaurantsObj = null;
            List<RestaurantsView> restaurantsView = new List<RestaurantsView>();

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(cuisineType))
            {
                restaurantsObj = db.Restaurants.Where(x => x.Name.Contains(name)).ToList();
            }
            if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(cuisineType))
            {
                int idCuisineType = db.CuisineTypes.Where(x => x.Name == cuisineType).FirstOrDefault().IdCuisine;
                restaurantsObj = db.Restaurants.Where(x => x.IdCuisine == idCuisineType).ToList();
            }
            else if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(cuisineType))
            {
                restaurantsObj = db.Restaurants.Where(x => x.Name.Contains(name)).ToList();
            }
            else
            {
                restaurantsObj = db.Restaurants.ToList();
            }

            if (restaurantsObj != null)
            {
                foreach (var item in restaurantsObj)
                {
                    restaurantsView.Add(TransformObject.TransformRestoObjIntoRestoView(item, db));
                }
            }
            return restaurantsView;
        }

        [Route("api/restaurants/getrestaurantsdetails")]
        public RestaurantsViewDetails GetRestaurantDetails(int id)
        {
            RestaurantsObj resto = db.Restaurants.Where(x => x.IdRestaurant == id).First();
            return TransformObject.TransformRestoObjIntoRestoViewDetails(resto,db);
        }

        [Route("api/restaurants/postrestaurant")]
        [ResponseType(typeof(RestaurantsCreate))]
        public IHttpActionResult PostRestaurant(RestaurantsCreate restaurantsC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int nb = 0;
            nb = db.CuisineTypes.Where(x => x.Name == restaurantsC.CuisineType).Count();
            if ( nb == 0)
            {
                CuisineTypeObj newCui = new CuisineTypeObj
                {
                    Name = restaurantsC.Name
                };
                db.CuisineTypes.Add(newCui);
            }
            int idCuisineType = db.CuisineTypes.Where(x => x.Name == restaurantsC.CuisineType).First().IdCuisine;
            RestaurantsObj newResto = new RestaurantsObj
            {
                Adress = restaurantsC.Adress,
                City = restaurantsC.City,
                IdCuisine = idCuisineType,
                Name = restaurantsC.Name,
                Phone = restaurantsC.Phone,
                PostalCode = restaurantsC.PostalCode,
                Rating = 10,
                urlThumbnail = restaurantsC.urlThumbnail
            };
            db.Restaurants.Add(newResto);
            db.SaveChanges();

            return Ok(TransformObject.TransformRestoObjIntoRestoViewDetails(newResto,db));
        }

        [HttpGet]
        [Route("api/restaurants/deleterestaurant")]
        [ResponseType(typeof(RestaurantsObj))]
        public IHttpActionResult DeleteRestaurant(int id)
        {
            RestaurantsObj restaurantsObj = db.Restaurants.Find(id);
            if (restaurantsObj == null)
            {
                return NotFound();
            }
            db.Restaurants.Remove(restaurantsObj);

            List<ImagesObj> imagesDel = db.Images.Where(x => x.IdRestaurant == id).ToList();
            foreach (var item in imagesDel)
            {
                db.Images.Remove(item);
            }

            List<DishesObj> dishesDel = db.Dishes.Where(x => x.IdRestaurant == id).ToList();
            foreach (var item in dishesDel)
            {
                db.Dishes.Remove(item);
            }
            db.SaveChanges();
            return Ok(restaurantsObj);
        }




        //// PUT: api/Restaurants/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutRestaurantsObj(int id, RestaurantsObj restaurantsObj)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != restaurantsObj.IdRestaurant)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(restaurantsObj).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RestaurantsObjExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

    }
}