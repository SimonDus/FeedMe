using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FeedMe.Models
{
    public class CuisineTypeObj
    {
        [Required]
        [Key]
        public int IdCuisine { get; set; }

        [Required]
        public string Name { get; set; }

    }
}