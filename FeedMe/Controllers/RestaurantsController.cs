using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FeedMe.Models;

namespace FeedMe.Controllers
{
    public class RestaurantsController : ApiController
    {
        private FeedMeContext db = new FeedMeContext();

        [Route("api/remplirdb")]
        public HttpResponseMessage remplirDbTest()
        {
            var test = new RestaurantsObj
            {
                Name = "Le rabassier",
                Adress = "23 rue de rollebeek",
                IdCuisine = -1,
                Phone = "0497756905",
                PostalCode = 1000
            };
            var test2 = new RestaurantsObj
            {
                Name = "Tonton garby",
                Adress = "6 rue duquesnoy",
                IdCuisine = -1,
                Phone = "0484290216",
                PostalCode = 1000
            };
            db.Restaurants.Add(test);
            db.Restaurants.Add(test2);
            db.SaveChanges();
            return null;
        }

        [Route("api/deldb")]
        public HttpResponseMessage delDbTest()
        {
            var tab = db.Restaurants.ToList();
            foreach (var item in tab)
            {
                db.Restaurants.Remove(item);
            }
            db.SaveChanges();
            return null;
        }

        // GET: get all restaurants
        [Route("api/restaurants/getrestaurants")]
        public List<RestaurantsObj> GetRestaurants()
        {
            List<RestaurantsObj> restoList = new List<RestaurantsObj> ()
            {
                new RestaurantsObj
                {
                    Name = "Le rabassier",
                    Adress = "23 rue de rollebeek",
                    IdCuisine = -1,
                    Phone = "0497756905",
                    PostalCode = 1000
                },
                new RestaurantsObj
                {
                    Name = "Tonton Garby",
                    Adress = "6 rue duquesnoy",
                    IdCuisine = -1,
                    Phone = "0484290216",
                    PostalCode = 1000
                },
                new RestaurantsObj
                {
                    Name = "The lobster house",
                    Adress = "39 rue des bouchers",
                    IdCuisine = -1,
                    Phone = "025022016",
                    PostalCode = 1000
                },
                new RestaurantsObj
                {
                    Name = "Pasta divana",
                    Adress = "16 rue de la montagne",
                    IdCuisine = -1,
                    Phone = "025112155",
                    PostalCode = 1000
                },
                new RestaurantsObj
                {
                    Name = "Vinomania",
                    Adress = "22 place fernand cocq",
                    IdCuisine = -1,
                    Phone = "0484223457",
                    PostalCode = 1050
                },
                new RestaurantsObj
                {
                    Name = "L'atelier de willy",
                    Adress = "118 boulevard emile jacqmain",
                    IdCuisine = -1,
                    Phone = "0471650827",
                    PostalCode = 1000
                },
                new RestaurantsObj
                {
                    Name = "Le bistro",
                    Adress = "138 boulevard de waterloo",
                    IdCuisine = -1,
                    Phone = "025394454",
                    PostalCode = 1000
                },
                new RestaurantsObj
                {
                    Name = "Au cor de chasse",
                    Adress = "21 avenue des casernes",
                    IdCuisine = -1,
                    Phone = "023085725",
                    PostalCode = 1040
                },
                new RestaurantsObj
                {
                    Name = "Le wine bar des marolles",
                    Adress = "198 rue haute",
                    IdCuisine = -1,
                    Phone = "0496820105",
                    PostalCode = 1000
                },
                new RestaurantsObj
                {
                    Name = "Mozart more than just ribs",
                    Adress = "18 petite rue des bouchers",
                    IdCuisine = -1,
                    Phone = "0493",
                    PostalCode = 1000
                }
            };
            return restoList;
        }

        // GET: get restaurants by name
        [ResponseType(typeof(RestaurantsObj))]
        [Route("api/restaurants/getrestaurantsbyname/{name}")]
        public IHttpActionResult GetRestaurantsByName(string name)
        {
            RestaurantsObj restaurantsObj = db.Restaurants.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault<RestaurantsObj>();
            if (restaurantsObj == null)
            {
                return NotFound();
            }

            return Ok(restaurantsObj);
        }

        // GET: get restaurants by cuisine type
        //[ResponseType(typeof(RestaurantsObj))]
        //[Route("api/restaurants/getrestaurantsbyname/{name}")]
        //public IHttpActionResult GetRestaurantsByName(string name)
        //{
        //    RestaurantsObj restaurantsObj = db.Restaurants.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault<RestaurantsObj>();
        //    if (restaurantsObj == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(restaurantsObj);
        //}



        // PUT: api/Restaurants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRestaurantsObj(int id, RestaurantsObj restaurantsObj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurantsObj.IdRestaurant)
            {
                return BadRequest();
            }

            db.Entry(restaurantsObj).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantsObjExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Restaurants
        [ResponseType(typeof(RestaurantsObj))]
        public IHttpActionResult PostRestaurantsObj(RestaurantsObj restaurantsObj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Restaurants.Add(restaurantsObj);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = restaurantsObj.IdRestaurant }, restaurantsObj);
        }

        // DELETE: api/Restaurants/5
        [ResponseType(typeof(RestaurantsObj))]
        public IHttpActionResult DeleteRestaurantsObj(int id)
        {
            RestaurantsObj restaurantsObj = db.Restaurants.Find(id);
            if (restaurantsObj == null)
            {
                return NotFound();
            }

            db.Restaurants.Remove(restaurantsObj);
            db.SaveChanges();

            return Ok(restaurantsObj);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantsObjExists(int id)
        {
            return db.Restaurants.Count(e => e.IdRestaurant == id) > 0;
        }
    }
}