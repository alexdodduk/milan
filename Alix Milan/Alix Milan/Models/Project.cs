using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alix_Milan.Models
{
    public class Project
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name="Date created")]
        public DateTime DateCreated { get; set; }

        [Required]
        public byte[] ImageBytes { get; set; }

        [Display(Name = "Youtube embed code")]
        public string VideoUrl { get; set; }
    }
}