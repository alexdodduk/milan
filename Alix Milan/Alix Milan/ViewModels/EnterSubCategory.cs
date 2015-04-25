using Alix_Milan.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alix_Milan.ViewModels
{
    public class EnterSubCategory
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Order { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public Dictionary<Category, IEnumerable<SubCategory>> CategorySubcategories { get; set; }
    }
}