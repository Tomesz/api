using System;
using System.Collections.Generic;

namespace pizza.Models
{
    public partial class Payments
    {
        public Payments()
        {
            Orders = new HashSet<Orders>();
        }

        public int PaymentId { get; set; }
        public int PaystatusId { get; set; }
        public int PaytypeId { get; set; }
        public DateTime StatusDate { get; set; }

        public virtual PaymentStatuses Paystatus { get; set; }
        public virtual PaymentTypes Paytype { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
