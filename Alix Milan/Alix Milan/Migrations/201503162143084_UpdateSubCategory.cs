namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSubCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SubCategories", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubCategories", "Name", c => c.String());
        }
    }
}
