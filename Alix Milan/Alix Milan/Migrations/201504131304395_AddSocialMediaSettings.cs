namespace Alix_Milan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSocialMediaSettings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SocialMediaSettings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FacebookUrl = c.String(),
                        TwitterUrl = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SocialMediaSettings");
        }
    }
}
