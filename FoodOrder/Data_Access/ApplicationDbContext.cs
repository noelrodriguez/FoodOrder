using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using FoodOrder.Models;
using System.Data.Entity;

namespace FoodOrder.Data_Access
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Subcategory> Subcategory { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<AddOn> AddOn { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}