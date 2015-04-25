using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alix_Milan.Models
{
    public class Kit
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

        public IEnumerable<KitItem> KitItems { get; set; }

        [Required]
        public byte[] ImageBytes { get; set; }   
    }
}