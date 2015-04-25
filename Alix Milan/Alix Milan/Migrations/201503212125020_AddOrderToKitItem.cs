namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderToKitItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.KitItems", "SubCategoryId", "dbo.SubCategories");
            DropIndex("dbo.KitItems", new[] { "SubCategoryId" });
            AddColumn("dbo.KitItems", "Order", c => c.Int(nullable: false));
            AlterColumn("dbo.KitItems", "SubCategoryId", c => c.Int());
            CreateIndex("dbo.KitItems", "SubCategoryId");
            AddForeignKey("dbo.KitItems", "SubCategoryId", "dbo.SubCategories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KitItems", "SubCategoryId", "dbo.SubCategories");
            DropIndex("dbo.KitItems", new[] { "SubCategoryId" });
            AlterColumn("dbo.KitItems", "SubCategoryId", c => c.Int(nullable: false));
            DropColumn("dbo.KitItems", "Order");
            CreateIndex("dbo.KitItems", "SubCategoryId");
            AddForeignKey("dbo.KitItems", "SubCategoryId", "dbo.SubCategories", "ID", cascadeDelete: true);
        }
    }
}
