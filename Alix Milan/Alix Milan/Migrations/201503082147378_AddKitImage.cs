namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKitImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kits", "ImageBytes", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kits", "ImageBytes");
        }
    }
}
