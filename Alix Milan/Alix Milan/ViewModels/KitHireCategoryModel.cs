using Alix_Milan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alix_Milan.ViewModels
{
    public class KitHireCategoryModel
    {
        public string Name { get; set; }
        public Dictionary<SubCategory, IEnumerable<KitItem>> SubcategoryKitItems { get; set; }
        public IEnumerable<KitItem> MiscKitItems { get; set; }
        public byte[] ImageBytes { get; set; }
    }
}