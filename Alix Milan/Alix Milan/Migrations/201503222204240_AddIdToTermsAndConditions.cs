namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdToTermsAndConditions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TermsAndConditions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TermsAndConditions");
        }
    }
}
