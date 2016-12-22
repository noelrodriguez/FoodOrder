namespace FoodOrder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyAddon : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AddOns", "CategoryID");
            AddForeignKey("dbo.AddOns", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AddOns", "CategoryID", "dbo.Categories");
            DropIndex("dbo.AddOns", new[] { "CategoryID" });
        }
    }
}
