using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alix_Milan.Models
{
    public class SubCategory
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}