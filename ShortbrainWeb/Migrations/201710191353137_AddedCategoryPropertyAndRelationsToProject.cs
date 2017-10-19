namespace ShortbrainWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCategoryPropertyAndRelationsToProject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Projects", "CategoryId", c => c.Byte(nullable: false));
            AddColumn("dbo.Projects", "Category_Id", c => c.Int());
            CreateIndex("dbo.Projects", "Category_Id");
            AddForeignKey("dbo.Projects", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Projects", new[] { "Category_Id" });
            DropColumn("dbo.Projects", "Category_Id");
            DropColumn("dbo.Projects", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
