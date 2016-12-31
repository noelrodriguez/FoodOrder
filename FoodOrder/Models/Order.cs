using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FoodOrder.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public ApplicationUser User { get; set; }
        [Required]
        public List<MenuItem> MenuItems { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        public Status Status { get; set; }
    }
}