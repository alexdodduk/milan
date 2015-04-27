using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alix_Milan.Models
{
    public class SocialMediaSettings
    {
        public int ID { get; set; }
        [DataType(DataType.Url)]
        [Display(Name="Facebook Url")]
        public string FacebookUrl { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Twitter Url")]
        public string TwitterUrl { get; set; }

        public static SocialMediaSettings GetSettings()
        {
            var db = new AppDbContext();

            return db.SocialMediaSettingses.FirstOrDefault();
        }
    }
}