using Alix_Milan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alix_Milan.ViewModels
{
    public class KitItemModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] ImageBytes { get; set; }
        public decimal Price { get; set; }
    }
}