namespace FoodOrder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddOns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        SubcategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subcategories", t => t.SubcategoryId, cascadeDelete: true)
                .Index(t => t.SubcategoryId);
            
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        SubcategoryId = c.Int(nullable: false),
                        ItemImage = c.Binary(),
                        Size = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subcategories", t => t.SubcategoryId, cascadeDelete: true)
                .Index(t => t.SubcategoryId);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Option = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.MenuItemAddOns",
                c => new
                    {
                        MenuItem_Id = c.Int(nullable: false),
                        AddOn_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MenuItem_Id, t.AddOn_Id })
                .ForeignKey("dbo.MenuItems", t => t.MenuItem_Id, cascadeDelete: true)
                .ForeignKey("dbo.AddOns", t => t.AddOn_Id, cascadeDelete: false)
                .Index(t => t.MenuItem_Id)
                .Index(t => t.AddOn_Id);
            
            CreateTable(
                "dbo.IngredientMenuItems",
                c => new
                    {
                        MenuItem_Id = c.Int(nullable: false),
                        Ingredient_Id = c.Int(nullable: false)
                    })
                .PrimaryKey(t => new { t.MenuItem_Id, t.Ingredient_Id })
                .ForeignKey("dbo.MenuItems", t => t.MenuItem_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_Id, cascadeDelete: true)
                .Index(t => t.MenuItem_Id)
                .Index(t => t.Ingredient_Id);
            
            CreateTable(
                "dbo.OrderMenuItems",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        MenuItem_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.MenuItem_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.MenuItems", t => t.MenuItem_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.MenuItem_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.MenuItems", "SubcategoryId", "dbo.Subcategories");
            DropForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.AddOns", "SubcategoryId", "dbo.Subcategories");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderMenuItems", "MenuItem_Id", "dbo.MenuItems");
            DropForeignKey("dbo.OrderMenuItems", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.IngredientMenuItems", "MenuItem_Id", "dbo.MenuItems");
            DropForeignKey("dbo.IngredientMenuItems", "Ingredient_Id", "dbo.Ingredients");
            DropForeignKey("dbo.MenuItemAddOns", "AddOn_Id", "dbo.AddOns");
            DropForeignKey("dbo.MenuItemAddOns", "MenuItem_Id", "dbo.MenuItems");
            DropIndex("dbo.OrderMenuItems", new[] { "MenuItem_Id" });
            DropIndex("dbo.OrderMenuItems", new[] { "Order_Id" });
            DropIndex("dbo.IngredientMenuItems", new[] { "MenuItem_Id" });
            DropIndex("dbo.IngredientMenuItems", new[] { "Ingredient_Id" });
            DropIndex("dbo.MenuItemAddOns", new[] { "AddOn_Id" });
            DropIndex("dbo.MenuItemAddOns", new[] { "MenuItem_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Subcategories", new[] { "CategoryId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.MenuItems", new[] { "SubcategoryId" });
            DropIndex("dbo.AddOns", new[] { "SubcategoryId" });
            DropTable("dbo.OrderMenuItems");
            DropTable("dbo.IngredientMenuItems");
            DropTable("dbo.MenuItemAddOns");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Categories");
            DropTable("dbo.Subcategories");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Orders");
            DropTable("dbo.Ingredients");
            DropTable("dbo.MenuItems");
            DropTable("dbo.AddOns");
        }
    }
}
