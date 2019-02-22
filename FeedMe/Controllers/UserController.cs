using FeedMe.Common;
using FeedMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace FeedMe.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "$")]
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private FeedMeContext db = new FeedMeContext();

        [Route("addrating")]
        public IHttpActionResult AddRating(int note, int idResto, int userId)
        {
            if(note<0 && note > 10)
            {
                return NotFound();
            }
            if(db.Ratings.Any(x => x.RestaurantId == idResto && x.UserId == userId))
            {
                return NotFound();
            }
            RatingsObj rating = new RatingsObj
            {
                Note = note,
                RestaurantId = idResto,
                UserId = userId
            };
            db.Ratings.Add(rating);
            db.SaveChanges();
            Tools.ratingAvg(idResto,db);
            return Ok();
        }

        [Route("addfavorites")]
        public IHttpActionResult AddFavorites(int userId, int restoId)
        {
            if (db.Favorites.Any(x => x.RestaurantId == restoId && x.UserId == userId))
            {
                return BadRequest();
            }
            FavoritesObj favorite = new FavoritesObj
            {
                RestaurantId = restoId,
                UserId = userId
            };
            db.Favorites.Add(favorite);
            db.SaveChanges();
            return Ok();
        }

        [ResponseType(typeof(List<FavoritesObj>))]
        public IHttpActionResult GetFavorites(int userId)
        {
            return Ok(db.Favorites.Where(x => x.UserId == userId).ToList());
        }

        public IHttpActionResult delFavorites(int userId, int restoId)
        {
            db.Favorites.Remove(db.Favorites.Where(x => x.UserId == userId && x.RestaurantId == restoId).First());
            db.SaveChanges();
            return Ok();
        }

    }
}
