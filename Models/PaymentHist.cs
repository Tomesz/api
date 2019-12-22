using System;
using System.Collections.Generic;

namespace pizza.Models
{
    public partial class PaymentHist
    {
        public int EndorseNo { get; set; }
        public int PaymentId { get; set; }
        public int PaystatusId { get; set; }
        public int PaytypeId { get; set; }
        public DateTime DateModified { get; set; }
    }
}
