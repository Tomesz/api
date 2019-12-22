using System;
using System.Collections.Generic;

namespace pizza.Models
{
    public partial class Persons
    {
        public Persons()
        {
            Deliverers = new HashSet<Deliverers>();
            Orders = new HashSet<Orders>();
        }

        public int PersonId { get; set; }
        public string Forenames { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public DateTime DateModified { get; set; }

        public virtual ICollection<Deliverers> Deliverers { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
