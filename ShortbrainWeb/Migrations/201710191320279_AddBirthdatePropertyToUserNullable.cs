namespace ShortbrainWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdatePropertyToUserNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Birthdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Birthdate", c => c.DateTime(nullable: false));
        }
    }
}
