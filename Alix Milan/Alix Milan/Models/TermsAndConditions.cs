using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alix_Milan.Models
{
    public class TermsAndConditions
    {
        public int ID { get; set; }

        [Required]
        [AllowHtml]
        public string Body { get; set; }
    }
}