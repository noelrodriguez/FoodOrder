using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodOrder.Models
{
    public class AddOn
    {
        public int Id { get; set; }
        public int SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}