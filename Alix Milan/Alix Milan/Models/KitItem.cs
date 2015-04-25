using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alix_Milan.Models
{
    public class KitItem
    {
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Order { get; set; }
        
        public Kit Kit { get; set; }

        public int? KitId { get; set; }

        [Required]
        public Category Category { get; set; }

        public int CategoryId { get; set; }

        [Display(Name="Sub-category")]
        public SubCategory SubCategory { get; set; }

        public int? SubCategoryId { get; set; }

        [Required]
        public byte[] ImageBytes { get; set; }
    }
}