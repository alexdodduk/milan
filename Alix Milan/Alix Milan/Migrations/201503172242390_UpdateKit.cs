namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateKit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kits", "SubCategory_ID", "dbo.SubCategories");
            DropIndex("dbo.Kits", new[] { "SubCategory_ID" });
            RenameColumn(table: "dbo.Kits", name: "Category_ID", newName: "CategoryId");
            RenameColumn(table: "dbo.Kits", name: "SubCategory_ID", newName: "SubCategoryId");
            RenameIndex(table: "dbo.Kits", name: "IX_Category_ID", newName: "IX_CategoryId");
            AlterColumn("dbo.Kits", "SubCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Kits", "SubCategoryId");
            AddForeignKey("dbo.Kits", "SubCategoryId", "dbo.SubCategories", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kits", "SubCategoryId", "dbo.SubCategories");
            DropIndex("dbo.Kits", new[] { "SubCategoryId" });
            AlterColumn("dbo.Kits", "SubCategoryId", c => c.Int());
            RenameIndex(table: "dbo.Kits", name: "IX_CategoryId", newName: "IX_Category_ID");
            RenameColumn(table: "dbo.Kits", name: "SubCategoryId", newName: "SubCategory_ID");
            RenameColumn(table: "dbo.Kits", name: "CategoryId", newName: "Category_ID");
            CreateIndex("dbo.Kits", "SubCategory_ID");
            AddForeignKey("dbo.Kits", "SubCategory_ID", "dbo.SubCategories", "ID");
        }
    }
}
