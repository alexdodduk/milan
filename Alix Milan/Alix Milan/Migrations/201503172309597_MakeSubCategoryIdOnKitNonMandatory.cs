namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeSubCategoryIdOnKitNonMandatory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kits", "SubCategoryId", "dbo.SubCategories");
            DropIndex("dbo.Kits", new[] { "SubCategoryId" });
            AlterColumn("dbo.Kits", "SubCategoryId", c => c.Int());
            CreateIndex("dbo.Kits", "SubCategoryId");
            AddForeignKey("dbo.Kits", "SubCategoryId", "dbo.SubCategories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kits", "SubCategoryId", "dbo.SubCategories");
            DropIndex("dbo.Kits", new[] { "SubCategoryId" });
            AlterColumn("dbo.Kits", "SubCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Kits", "SubCategoryId");
            AddForeignKey("dbo.Kits", "SubCategoryId", "dbo.SubCategories", "ID", cascadeDelete: true);
        }
    }
}
