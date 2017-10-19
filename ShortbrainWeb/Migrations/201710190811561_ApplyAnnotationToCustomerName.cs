namespace ShortbrainWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationToCustomerName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Username", c => c.String());
        }
    }
}
