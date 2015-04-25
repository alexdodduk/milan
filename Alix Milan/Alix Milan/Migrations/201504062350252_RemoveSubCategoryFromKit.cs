namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSubCategoryFromKit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kits", "SubCategoryId", "dbo.SubCategories");
            DropIndex("dbo.Kits", new[] { "SubCategoryId" });
            DropColumn("dbo.Kits", "SubCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kits", "SubCategoryId", c => c.Int());
            CreateIndex("dbo.Kits", "SubCategoryId");
            AddForeignKey("dbo.Kits", "SubCategoryId", "dbo.SubCategories", "ID");
        }
    }
}
