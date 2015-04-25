using Alix_Milan.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alix_Milan.ViewModels
{
    public class EnterKit
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public decimal? Price { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<SubCategory> SubCategories { get; set; }

        [Display(Name = "Upload image")]
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name="Image")]
        public byte[] ExistingImageBytes { get; set; }
    }
}