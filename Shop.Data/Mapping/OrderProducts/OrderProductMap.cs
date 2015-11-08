using Shop.Core.Domain.OrderProducts;

namespace Shop.Data.Mapping.OrderProducts
{
    public partial class OrderProductMap : ShopEntityTypeConfiguration<OrderProduct>
    {
        public OrderProductMap()
        {
            ToTable("OrderProducts");
            HasKey(op => op.Id);
        }
    }
}
