using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodOrder.Models
{
    public class Ingredients
    {
        public int IngredientsID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public enum Option { NORMAL, NONE, LOW }
    }
}