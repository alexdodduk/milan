namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kits", "CategoryId", "dbo.Categories");
        }

        public override void Down()
        {
            AddForeignKey("dbo.Kits", "CategoryId", "dbo.Categories", "ID", cascadeDelete: true);
        }
    }
}
