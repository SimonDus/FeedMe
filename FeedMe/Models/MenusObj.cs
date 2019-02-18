using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FeedMe.Models
{
    public class MenusObj
    {
        [Key]
        [Required]
        public int IdMenu { get; set; }

        [Required]
        public int IdRestaurant { get; set; }
    }
}