using System;
using System.Collections.Generic;

namespace pizza.Models
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public int PersonId { get; set; }
        public int StatusId { get; set; }
        public DateTime StatusDate { get; set; }
        public int PizzaId { get; set; }
        public int DeliveryId { get; set; }
        public int PaymentsPaymentId { get; set; }
        public int? DiscountId { get; set; }
        public decimal Price { get; set; }

        public virtual Deliveries Delivery { get; set; }
        public virtual Discounts Discount { get; set; }
        public virtual Payments PaymentsPayment { get; set; }
        public virtual Persons Person { get; set; }
        public virtual Pizzas Pizza { get; set; }
        public virtual OrderStatuses Status { get; set; }
    }
}
