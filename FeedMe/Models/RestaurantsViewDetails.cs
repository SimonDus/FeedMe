using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeedMe.Models
{
    public class RestaurantsViewDetails
    {
        public int IdRestaurant { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public int PostalCode { get; set; }

        public string Phone { get; set; }

        public string CuisineType { get; set; }

        public string urlThumbnail { get; set; }

        public string City { get; set; }

        public double Rating { get; set; }

        public List<ImagesObj> Images { get; set; }

        public List<DishesObj> Dishes { get; set; }

    }
}