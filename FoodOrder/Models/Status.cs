using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodOrder.Models
{
    public enum Status
    {
        CART,
        RECEIVED,
        IN_PROGRESS,
        PICK_UP,
        COMPLETED
    }
}