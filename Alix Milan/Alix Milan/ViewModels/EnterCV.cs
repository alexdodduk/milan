using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alix_Milan.ViewModels
{
    public class EnterCV
    {
        public int ID { get; set; }

        [Required]
        public HttpPostedFileBase File { get; set; }

        [Display(Name = "Existing file")]
        public byte[] ExistingFile { get; set; }
    }
}