namespace ShortbrainWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DiscountRate) VALUES (1,0,0)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DiscountRate) VALUES (2,10,10)");
        }
        
        public override void Down()
        {
        }
    }
}
