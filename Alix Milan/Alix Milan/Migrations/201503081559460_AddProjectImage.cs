namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjectImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ImageBytes", c => c.Binary(nullable: false));
            AddColumn("dbo.Projects", "VideoURL", c => c.String());
            AlterColumn("dbo.Projects", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Description", c => c.String());
            AlterColumn("dbo.Projects", "Name", c => c.String());
            DropColumn("dbo.Projects", "VideoURL");
            DropColumn("dbo.Projects", "ImageBytes");
        }
    }
}
