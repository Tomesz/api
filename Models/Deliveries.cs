using System;
using System.Collections.Generic;

namespace pizza.Models
{
    public partial class Deliveries
    {
        public Deliveries()
        {
            Orders = new HashSet<Orders>();
        }

        public int DeliveryId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DeliveyDate { get; set; }
        public int DelivererId { get; set; }
        public int AddressId { get; set; }
        public int Available { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual Deliverers Deliverer { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
