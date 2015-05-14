using Alix_Milan.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public DbSet<About> Abouts { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<Kit> Kits { get; set; }

        public DbSet<KitItem> KitItems { get; set; }

        public DbSet<TermsAndConditions> TermsAndConditionses { get; set; }

        public DbSet<SocialMediaSettings> SocialMediaSettingses { get; set; }

        public DbSet<CV> CVs { get; set; }
    }
}