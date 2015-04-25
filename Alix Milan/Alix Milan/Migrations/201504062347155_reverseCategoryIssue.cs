namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reverseCategoryIssue : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Kits", "CategoryId", c => c.Int(nullable: false));
            //AddColumn("dbo.Kits", "SubCategoryId", c => c.Int());
            //CreateIndex("dbo.Kits", "CategoryId");
            //CreateIndex("dbo.Kits", "SubCategoryId");
            //AddForeignKey("dbo.Kits", "CategoryId", "dbo.Categories", "ID", cascadeDelete: true);
            //AddForeignKey("dbo.Kits", "SubCategoryId", "dbo.SubCategories", "ID");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Kits", "SubCategoryId", "dbo.SubCategories");
            //DropForeignKey("dbo.Kits", "CategoryId", "dbo.Categories");
            //DropIndex("dbo.Kits", new[] { "SubCategoryId" });
            //DropIndex("dbo.Kits", new[] { "CategoryId" });
            //DropColumn("dbo.Kits", "SubCategoryId");
            //DropColumn("dbo.Kits", "CategoryId");
        }
    }
}
