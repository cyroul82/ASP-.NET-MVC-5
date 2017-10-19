namespace ShortbrainWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsSubscribedToNewsLetter");
        }
    }
}
