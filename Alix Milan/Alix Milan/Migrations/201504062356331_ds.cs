namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ds : DbMigration
    {
        public override void Up()
        {
            //CreateIndex("dbo.Kits", "CategoryId");
            //AddForeignKey("dbo.Kits", "CategoryId", "dbo.Categories", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Kits", "CategoryId", "dbo.Categories");
            //DropIndex("dbo.Kits", new[] { "CategoryId" });
        }
    }
}
