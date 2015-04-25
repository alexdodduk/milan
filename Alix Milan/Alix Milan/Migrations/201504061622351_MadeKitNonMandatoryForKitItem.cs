namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeKitNonMandatoryForKitItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.KitItems", "KitId", "dbo.Kits");
            DropIndex("dbo.KitItems", new[] { "KitId" });
            AlterColumn("dbo.KitItems", "KitId", c => c.Int());
            CreateIndex("dbo.KitItems", "KitId");
            AddForeignKey("dbo.KitItems", "KitId", "dbo.Kits", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KitItems", "KitId", "dbo.Kits");
            DropIndex("dbo.KitItems", new[] { "KitId" });
            AlterColumn("dbo.KitItems", "KitId", c => c.Int(nullable: false));
            CreateIndex("dbo.KitItems", "KitId");
            AddForeignKey("dbo.KitItems", "KitId", "dbo.Kits", "ID", cascadeDelete: true);
        }
    }
}
