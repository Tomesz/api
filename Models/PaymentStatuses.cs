using System;
using System.Collections.Generic;

namespace pizza.Models
{
    public partial class PaymentStatuses
    {
        public PaymentStatuses()
        {
            Payments = new HashSet<Payments>();
        }

        public int PaystatusId { get; set; }
        public string StatusDesc { get; set; }

        public virtual ICollection<Payments> Payments { get; set; }
    }
}
