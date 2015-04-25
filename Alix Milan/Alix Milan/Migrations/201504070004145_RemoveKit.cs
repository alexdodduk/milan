namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveKit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kits", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Kits", new[] { "CategoryId" });
            //DropColumn("dbo.Kits", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kits", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Kits", "CategoryId");
            //AddForeignKey("dbo.Kits", "CategoryId", "dbo.Categories", "ID", cascadeDelete: true);
        }
    }
}
