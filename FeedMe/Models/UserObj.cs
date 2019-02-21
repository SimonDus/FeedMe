using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FeedMe.Models
{
    public class UserObj
    {
        [Required]
        [Key]
        public int UserId { get; set; }

        [Required]
        public int Role { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string MailAdress { get; set; }

        public string Birthdate { get; set; }

        [MaxLength(1)]
        public string Gender { get; set; }

    }
}