using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodOrder.Models
{
    public enum Status
    {
        Cart,
        Received,
        In_Progress,
        Pick_Up,
        Completed
    }
}