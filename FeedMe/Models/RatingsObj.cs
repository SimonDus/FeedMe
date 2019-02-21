using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FeedMe.Models
{
    public class RatingsObj
    {
        [Key]
        [Required]
        public int RatinId { get; set; }
        [Required]
        public int RestaurantI { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public double Note { get; set; }

    }
}