using System;
using System.Collections.Generic;

namespace pizza.Models
{
    public partial class Discounts
    {
        public Discounts()
        {
            Orders = new HashSet<Orders>();
        }

        public int DiscountId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DiscoutPerc { get; set; }
        public int Available { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

        public static String InsertDisctount(Discounts d)
        {
            
            return "OK";
        }

    }
}
