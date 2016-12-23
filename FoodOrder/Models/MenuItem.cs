using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodOrder.Models
{
    public class MenuItem
    {
        public int MenuItemID { get; set; }
        public int SubcategoryID { get; set; }
        public Subcategory Subcategory { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Size? Size { get; set; }
        public List<AddOn> AddOns { get; set; }
    }
}