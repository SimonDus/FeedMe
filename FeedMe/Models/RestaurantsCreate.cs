using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeedMe.Models
{
    public class RestaurantsCreate
    {
        public string Name { get; set; }

        public string Adress { get; set; }

        public int PostalCode { get; set; }

        public string Phone { get; set; }

        public string CuisineType { get; set; }

        public string urlThumbnail { get; set; }

        public string City { get; set; }

    }
}