using System;
using System.Collections.Generic;

namespace pizza.Models
{
    public partial class OrderHist
    {
        public int EndorseNo { get; set; }
        public int OrderId { get; set; }
        public int StatusId { get; set; }
        public int PizzaId { get; set; }
        public int DeliveryId { get; set; }
        public int PaymentsPaymentId { get; set; }
        public int? DiscountId { get; set; }
        public DateTime DateModified { get; set; }
    }
}
