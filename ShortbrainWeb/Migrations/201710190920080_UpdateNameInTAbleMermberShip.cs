namespace ShortbrainWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameInTAbleMermberShip : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set Name='Beginner' where Id=1");
            Sql("update MembershipTypes set Name='Expert' where Id=2");
        }
        
        public override void Down()
        {
        }
    }
}
