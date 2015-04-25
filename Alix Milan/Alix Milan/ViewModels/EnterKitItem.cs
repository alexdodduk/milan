using Alix_Milan.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alix_Milan.ViewModels
{
    public class EnterKitItem
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public int Order { get; set; }

        [Display(Name = "Kit")]
        public int? KitId { get; set; }

        public Kit Kit { get; set; }

        [Required]
        [Display(Name="Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Display(Name="Sub-category")]
        public int? SubCategoryId { get; set; }

        public SubCategory SubCategory { get; set; }

        [Display(Name = "Upload image")]
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name="Image")]
        public byte[] ExistingImageBytes { get; set; }

        public IEnumerable<Category> Categories { get; set; }  

        public IEnumerable<SubCategory> SubCategories { get; set; }

        public IEnumerable<Kit> Kits { get; set; }  
    }
}