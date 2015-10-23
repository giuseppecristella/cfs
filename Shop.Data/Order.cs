using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime SubmissionDate { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerSecondName { get; set; }
        public string CustomerAddress { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentType { get; set; }
        public string Total { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
