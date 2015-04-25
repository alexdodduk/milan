namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredAttributesToTermsAndConditions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TermsAndConditions", "Body", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TermsAndConditions", "Body", c => c.String());
        }
    }
}
