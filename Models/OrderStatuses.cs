using System;
using System.Collections.Generic;

namespace pizza.Models
{
    public partial class OrderStatuses
    {
        public OrderStatuses()
        {
            Orders = new HashSet<Orders>();
        }

        public int StatusId { get; set; }
        public string StatusDesc { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
