using System;
using System.Collections.Generic;

namespace pizza.Models
{
    public partial class PaymentTypes
    {
        public PaymentTypes()
        {
            Payments = new HashSet<Payments>();
        }

        public int PaytypeId { get; set; }
        public string TypeDesc { get; set; }

        public virtual ICollection<Payments> Payments { get; set; }
    }
}
