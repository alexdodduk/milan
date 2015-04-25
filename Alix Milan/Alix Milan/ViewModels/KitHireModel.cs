using Alix_Milan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alix_Milan.ViewModels
{
    public class KitHireModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Kit> Kits { get; set; }
    }
}