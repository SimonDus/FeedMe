﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FeedMe.Models
{
    public class DishesObj
    {
        [Key]
        [Required]
        public int IdDishes { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int IdRestaurant { get; set; }

        [MaxLength(1)]
        public string Pde { get; set; }
    }
}