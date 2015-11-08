using System;
using System.Collections.Generic;
using Shop.Core.Domain.OrderProducts;

namespace Shop.Core.Domain.Orders
{
    public partial class Order : BaseEntity
    {
        public DateTime SubmissionDate { get; set; }
        public int MagentoOrderId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerSecondName { get; set; }
        public string CustomerAddress { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentType { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Shipment { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
