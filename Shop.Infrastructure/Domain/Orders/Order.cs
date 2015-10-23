using System;

namespace Shop.Core.Domain.Orders
{
    public partial class Order : BaseEntity
    {
        public DateTime SubmissionDate { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerSecondName { get; set; }
        public string CustomerAddress { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentType { get; set; }
        public string Total { get; set; }
    }
}
