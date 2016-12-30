using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrder.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Subcategory Subcategory { get; set; }
        public byte[] ItemImage { get; set; }
        public Size? Size { get; set; }
        public List<AddOn> AddOns { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}