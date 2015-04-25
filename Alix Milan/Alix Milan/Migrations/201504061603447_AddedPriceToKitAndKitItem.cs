namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPriceToKitAndKitItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KitItems", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Kits", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kits", "Price");
            DropColumn("dbo.KitItems", "Price");
        }
    }
}
