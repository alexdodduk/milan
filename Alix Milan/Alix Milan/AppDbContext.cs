using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alix_Milan
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
            : base("DefaultConnection")
        {
        }
        public System.Data.Entity.DbSet<Alix_Milan.Models.About> Abouts { get; set; }

        public System.Data.Entity.DbSet<Alix_Milan.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<Alix_Milan.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<Alix_Milan.Models.SubCategory> SubCategories { get; set; }

        public System.Data.Entity.DbSet<Alix_Milan.Models.Kit> Kits { get; set; }

        public System.Data.Entity.DbSet<Alix_Milan.Models.KitItem> KitItems { get; set; }

        public System.Data.Entity.DbSet<Alix_Milan.Models.TermsAndConditions> TermsAndConditionses { get; set; }

        public System.Data.Entity.DbSet<Alix_Milan.Models.SocialMediaSettings> SocialMediaSettingses { get; set; }
    }
}