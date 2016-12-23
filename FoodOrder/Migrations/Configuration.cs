namespace FoodOrder.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FoodOrder.Data_Access.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FoodOrder.Data_Access.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Category.AddOrUpdate(
                p => p.Name,
                new Models.Category { Name = "Appetizer", Description = "Finger Food" },
                new Models.Category { Name = "Entree", Description = "Main Dish" },
                new Models.Category { Name = "Dessert", Description = "For Last" },
                new Models.Category { Name = "Drinks", Description = "Satisfy Thirst" }
            );

            context.Subcategory.AddOrUpdate(
                p => p.Name,
                new Models.Subcategory { Name = "Finger Food", CategoryId = 9 },
                new Models.Subcategory { Name = "Small Serving", CategoryId = 9 },
                new Models.Subcategory { Name = "Burgers", CategoryId = 10 },
                new Models.Subcategory { Name = "Soups", CategoryId = 10 },
                new Models.Subcategory { Name = "Pie", CategoryId = 11 },
                new Models.Subcategory { Name = "Cake", CategoryId = 11 },
                new Models.Subcategory { Name = "Espresso", CategoryId = 12 },
                new Models.Subcategory { Name = "Soda", CategoryId = 12 }
            );

            context.MenuItem.AddOrUpdate(
                p => p.Name,
                new Models.MenuItem { Name = "Mozarella Sticks", SubcategoryId = 2, Description = "A", Price = 5.0 },
                new Models.MenuItem { Name = "Guac", SubcategoryId = 3, Description = "B", Price = 3.5 },
                new Models.MenuItem { Name = "Cowboy Burger", SubcategoryId = 4, Description = "C", Price = 11.0 },
                new Models.MenuItem { Name = "Deluxe Burger", SubcategoryId = 4, Description = "D", Price = 9.0 },
                new Models.MenuItem { Name = "Tomato Souop", SubcategoryId = 5, Description = "E", Price = 2.0 },
                new Models.MenuItem { Name = "Pumpkin Pie", SubcategoryId = 6, Description = "F", Price = 2.0 },
                new Models.MenuItem { Name = "Chocolate Cake", SubcategoryId = 7, Description = "G", Price = 4.6 },
                new Models.MenuItem { Name = "Latte", SubcategoryId = 8, Description = "H", Price = 3.0, Size = Models.Size.LARGE},
                new Models.MenuItem { Name = "Mocha", SubcategoryId = 8, Description = "I", Price = 4.5, Size = Models.Size.MEDIUM },
                new Models.MenuItem { Name = "Coca Cola", SubcategoryId = 9, Description = "J", Price = 1.0 },
                new Models.MenuItem { Name = "Pepsi", SubcategoryId = 9, Description = "K", Price = 0.99 });
        }
    }
}
