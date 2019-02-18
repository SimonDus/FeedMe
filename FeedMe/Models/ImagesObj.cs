using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FeedMe.Models
{
    public class ImagesObj
    {
        [Required]
        [Key]
        public int IdImage { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public int IdRestaurant { get; set; }
    }
}