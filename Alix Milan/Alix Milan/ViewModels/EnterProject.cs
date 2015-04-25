using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alix_Milan.ViewModels
{
    public class EnterProject
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Date created")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Upload image")]
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name = "Image")]
        public byte[] ExistingImageBytes { get; set; }

        [Display(Name = "Youtube embed code")]
        [AllowHtml]
        public string VideoUrl { get; set; }
    }
}