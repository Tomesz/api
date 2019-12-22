using System;
using System.Collections.Generic;

namespace pizza.Models
{
    public partial class Ingredients
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Available { get; set; }
    }
}
