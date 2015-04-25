namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixing : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SubCategories", name: "Category_ID", newName: "CategoryId");
            RenameIndex(table: "dbo.SubCategories", name: "IX_Category_ID", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SubCategories", name: "IX_CategoryId", newName: "IX_Category_ID");
            RenameColumn(table: "dbo.SubCategories", name: "CategoryId", newName: "Category_ID");
        }
    }
}
