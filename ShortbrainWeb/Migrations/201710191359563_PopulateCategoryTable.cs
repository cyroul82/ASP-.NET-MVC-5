namespace ShortbrainWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Name) VALUES ('C# .Net')");
            Sql("INSERT INTO Categories (Name) VALUES ('Angular')");
            Sql("INSERT INTO Categories (Name) VALUES ('Php')");
            Sql("INSERT INTO Categories (Name) VALUES ('Android')");
        }
        
        public override void Down()
        {
        }
    }
}
