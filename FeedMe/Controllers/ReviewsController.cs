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
    [RoutePrefix("api/Reviews")]
    [EnableCors(origins: "*", headers: "*", methods: "$")]
    public class ReviewsController : ApiController
    {
        private FeedMeContext db = new FeedMeContext();


        [ResponseType(typeof(List<ReviewsObj>))]
        [Route("getreviews")]
        public IHttpActionResult GetReviewsObj(int resotId, int? userId = null)
        {
            if (userId != null)
            {
               return Ok(db.Reviews.Where(x => x.RestaurantID == resotId && x.UserId == userId).ToList());
            }

            return Ok(db.Reviews.Where(x => x.RestaurantID == resotId).ToList());
        }
    }
}