namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedCategoryAndSubCategoryFromKit : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Kits", "CategoryId", "dbo.Categories");
            //DropForeignKey("dbo.Kits", "SubCategoryId", "dbo.SubCategories");
            //DropIndex("dbo.Kits", new[] { "CategoryId" });
            //DropIndex("dbo.Kits", new[] { "SubCategoryId" });
            //DropColumn("dbo.Kits", "CategoryId");
            //DropColumn("dbo.Kits", "SubCategoryId");
        }
        
        public override void Down()
        {
        //    AddColumn("dbo.Kits", "SubCategoryId", c => c.Int());
        //    AddColumn("dbo.Kits", "CategoryId", c => c.Int(nullable: false));
        //    CreateIndex("dbo.Kits", "SubCategoryId");
        //    CreateIndex("dbo.Kits", "CategoryId");
        //    AddForeignKey("dbo.Kits", "SubCategoryId", "dbo.SubCategories", "ID");
        //    AddForeignKey("dbo.Kits", "CategoryId", "dbo.Categories", "ID", cascadeDelete: true);
        }
    }
}
