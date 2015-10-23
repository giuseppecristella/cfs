namespace Shop.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class OrderProduct
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
