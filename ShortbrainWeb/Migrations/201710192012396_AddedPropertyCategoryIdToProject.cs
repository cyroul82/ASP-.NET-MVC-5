namespace ShortbrainWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPropertyCategoryIdToProject : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Projects", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Projects", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.Projects", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "CategoryId");
            AddForeignKey("dbo.Projects", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Projects", new[] { "CategoryId" });
            AlterColumn("dbo.Projects", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Projects", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Projects", "Category_Id");
            AddForeignKey("dbo.Projects", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
