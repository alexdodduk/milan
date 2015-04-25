namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageToCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ImageBytes", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "ImageBytes");
        }
    }
}
