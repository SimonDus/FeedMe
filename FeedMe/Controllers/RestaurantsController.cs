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

        // GET: get all restaurants
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

        //[Route("api/restaurants/getmenu")]
        //public List<DishesObj> GetMenu(int idRestaurant = 0)
        //{
        //    List<DishesObj> menu = new List<DishesObj>();
        //    if(db.Restaurants.Select(x => x.IdRestaurant).ToList().Contains(idRestaurant))
        //    {
        //        menu = db.Dishes.Where(x => x.IdRestaurant == idRestaurant).ToList();
        //    }
        //    return menu;
        //}

        //[Route("api/restaurants/getimages")]
        //public List<ImagesObj> GetImages(int idRestaurant = 0)
        //{
        //    List<ImagesObj> images = new List<ImagesObj>();
        //    if (db.Restaurants.Select(x => x.IdRestaurant).ToList().Contains(idRestaurant))
        //    {
        //        images = db.Images.Where(x => x.IdRestaurant == idRestaurant).ToList();
        //    }
        //    return images;
        //}

        [Route("api/restaurants/getrestaurantsdetails")]
        public RestaurantsViewDetails GetRestaurantDetails(int id)
        {
            RestaurantsObj resto = db.Restaurants.Where(x => x.IdRestaurant == id).First();
            return TransformObject.TransformRestoObjIntoRestoViewDetails(resto,db);
        }


        //// POST: api/Restaurants
        //[ResponseType(typeof(RestaurantsObj))]
        //public IHttpActionResult PostRestaurantsObj(RestaurantsObj restaurantsObj)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Restaurants.Add(restaurantsObj);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = restaurantsObj.IdRestaurant }, restaurantsObj);
        //}





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

        //// DELETE: api/Restaurants/5
        //[ResponseType(typeof(RestaurantsObj))]
        //public IHttpActionResult DeleteRestaurantsObj(int id)
        //{
        //    RestaurantsObj restaurantsObj = db.Restaurants.Find(id);
        //    if (restaurantsObj == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Restaurants.Remove(restaurantsObj);
        //    db.SaveChanges();

        //    return Ok(restaurantsObj);
        //}

    }
}