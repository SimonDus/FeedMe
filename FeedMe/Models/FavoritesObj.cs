using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FeedMe.Models
{
    public class FavoritesObj
    {
        [Key]
        [Required]
        public int FavoriteId { get; set; }
        [Required]
        public int RestaurantId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}