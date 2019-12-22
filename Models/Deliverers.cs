using System;
using System.Collections.Generic;

namespace pizza.Models
{
    public partial class Deliverers
    {
        public Deliverers()
        {
            Deliveries = new HashSet<Deliveries>();
        }

        public int DelivererId { get; set; }
        public int PersonId { get; set; }
        public DateTime HiredFrom { get; set; }
        public DateTime? HiredTo { get; set; }
        public decimal Rate { get; set; }

        public virtual Persons Person { get; set; }
        public virtual ICollection<Deliveries> Deliveries { get; set; }
    }
}
