namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aw : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Kits", "Category_ID", "dbo.Categories");
            //DropIndex("dbo.Kits", new[] { "Category_ID" });
            //AddColumn("dbo.Kits", "CategoryId", c => c.Int(nullable: false));
            //DropColumn("dbo.Kits", "Category_ID");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Kits", "Category_ID", c => c.Int());
            //DropColumn("dbo.Kits", "CategoryId");
            //CreateIndex("dbo.Kits", "Category_ID");
            //AddForeignKey("dbo.Kits", "Category_ID", "dbo.Categories", "ID");
        }
    }
}
