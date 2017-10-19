namespace ShortbrainWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCategoryIdPropertyToProjetctBecauseUseless : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projects", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "CategoryId", c => c.Byte(nullable: false));
        }
    }
}
