namespace Shop.Core.Domain.OrderProducts
{
    public class OrderProduct: BaseEntity
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
