using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodOrder.Models
{
    public class Order
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public double TotalPrice { get; set; }
        public Status Status { get; set; }
    }
}