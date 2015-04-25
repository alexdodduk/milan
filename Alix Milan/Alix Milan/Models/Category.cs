using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alix_Milan.Models
{
    public class Category
    {
        [Required]
        public int ID {  get; set; }

        [Required]
        public string Name { get; set; }
        public int Order { get; set; }

        public byte[] ImageBytes { get; set; }
    }
}