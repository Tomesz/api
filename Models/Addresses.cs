using System;
using System.Collections.Generic;

namespace pizza.Models
{
    public partial class Addresses
    {
        public Addresses()
        {
            Deliveries = new HashSet<Deliveries>();
        }

        public int AddressId { get; set; }
        public string Street { get; set; }
        public int StreetNo { get; set; }
        public int? FlatNo { get; set; }
        public string PostCode { get; set; }
        public DateTime DateModified { get; set; }

        public virtual ICollection<Deliveries> Deliveries { get; set; }
    }
}
