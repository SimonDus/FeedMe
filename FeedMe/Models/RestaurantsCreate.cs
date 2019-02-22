using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FeedMe.Models
{
    public class RestaurantsCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public int PostalCode { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string CuisineType { get; set; }
        [Required]
        public string urlThumbnail { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public List<DishesCreate> Plats { get; set; }

    }
}