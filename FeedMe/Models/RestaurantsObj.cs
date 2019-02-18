using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FeedMe.Models
{
    public class RestaurantsObj
    {
        [Required]
        [Key]
        public int IdRestaurant { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public int PostalCode { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public int IdCuisine { get; set; }





    }
}