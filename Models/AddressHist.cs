using System;
using System.Collections.Generic;

namespace pizza.Models
{
    public partial class AddressHist
    {
        public int EndorseNo { get; set; }
        public int AddressId { get; set; }
        public string Street { get; set; }
        public int StreetNo { get; set; }
        public int? FlatNo { get; set; }
        public string PostCode { get; set; }
        public DateTime DateModified { get; set; }
    }
}
