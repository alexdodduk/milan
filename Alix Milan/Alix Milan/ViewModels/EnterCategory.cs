using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alix_Milan.ViewModels
{
    public class EnterCategory
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Order { get; set; }

        [Display(Name="Upload image")]
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name = "Image")]
        public byte[] ExistingImageBytes { get; set; }
    }
}