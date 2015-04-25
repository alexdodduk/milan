namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKitIdToKitItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.KitItems", "SubCategory_ID", "dbo.SubCategories");
            DropIndex("dbo.KitItems", new[] { "SubCategory_ID" });
            RenameColumn(table: "dbo.KitItems", name: "Category_ID", newName: "CategoryId");
            RenameColumn(table: "dbo.KitItems", name: "SubCategory_ID", newName: "SubCategoryId");
            RenameIndex(table: "dbo.KitItems", name: "IX_Category_ID", newName: "IX_CategoryId");
            AddColumn("dbo.KitItems", "KitId", c => c.Int(nullable: false));
            AlterColumn("dbo.KitItems", "SubCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.KitItems", "KitId");
            CreateIndex("dbo.KitItems", "SubCategoryId");
            AddForeignKey("dbo.KitItems", "KitId", "dbo.Kits", "ID", cascadeDelete: false);
            AddForeignKey("dbo.KitItems", "SubCategoryId", "dbo.SubCategories", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KitItems", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.KitItems", "KitId", "dbo.Kits");
            DropIndex("dbo.KitItems", new[] { "SubCategoryId" });
            DropIndex("dbo.KitItems", new[] { "KitId" });
            AlterColumn("dbo.KitItems", "SubCategoryId", c => c.Int());
            DropColumn("dbo.KitItems", "KitId");
            RenameIndex(table: "dbo.KitItems", name: "IX_CategoryId", newName: "IX_Category_ID");
            RenameColumn(table: "dbo.KitItems", name: "SubCategoryId", newName: "SubCategory_ID");
            RenameColumn(table: "dbo.KitItems", name: "CategoryId", newName: "Category_ID");
            CreateIndex("dbo.KitItems", "SubCategory_ID");
            AddForeignKey("dbo.KitItems", "SubCategory_ID", "dbo.SubCategories", "ID");
        }
    }
}
