using System;
using System.Collections.Generic;

namespace pizza.Models
{
    public partial class Pizzas
    {
        public Pizzas()
        {
            Orders = new HashSet<Orders>();
        }

        public int PizzaId { get; set; }
        public string Name { get; set; }
        public string PizzaDesc { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
