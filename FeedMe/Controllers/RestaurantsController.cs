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
using FeedMe.Models;

namespace FeedMe.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "$")]
    public class RestaurantsController : ApiController
    {
        private FeedMeContext db = new FeedMeContext();

        // GET: get all restaurants
        [Route("api/restaurants/getrestaurants")]
        public List<RestaurantsObj> GetRestaurants(string name = "", string cuisineType = "")
        {
            if(!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(cuisineType))
            {
                List<RestaurantsObj> restaurantsObj = db.Restaurants.Where(x => x.Name.Contains(name)).ToList();
                return (restaurantsObj);
            }
            if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(cuisineType))
            {
                int idCuisineType = db.CuisineTypes.Where(x => x.Name == cuisineType).FirstOrDefault().IdCuisine;
                List<RestaurantsObj> restaurantsObjCuisine = db.Restaurants.Where(x => x.IdCuisine == idCuisineType).ToList();
                return restaurantsObjCuisine;
            }
            else if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(cuisineType))
            {
                List<RestaurantsObj> restaurantsObj = db.Restaurants.Where(x => x.Name.Contains(name)).ToList();
                return (restaurantsObj);
            }
            else
            {
                return db.Restaurants.ToList();
            }
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

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool RestaurantsObjExists(int id)
        //{
        //    return db.Restaurants.Count(e => e.IdRestaurant == id) > 0;
        //}
    }
}