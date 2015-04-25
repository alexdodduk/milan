namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderToKit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kits", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kits", "Order");
        }
    }
}
