namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKitItemImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KitItems", "ImageBytes", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KitItems", "ImageBytes");
        }
    }
}
