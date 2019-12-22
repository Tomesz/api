using System;
using System.Collections.Generic;

namespace pizza.Models
{
    public partial class PersonHist
    {
        public int EndorseNo { get; set; }
        public int PersonId { get; set; }
        public string Forenames { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public DateTime DateModified { get; set; }
    }
}
