using Shop.Core.Domain.Orders;

namespace Shop.Data.Mapping.Orders
{
    public partial class OrderMap : ShopEntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("Orders");
            HasKey(o => o.Id);

            HasMany(o => o.OrderProducts)
                .WithRequired(o => o.Order)
                .HasForeignKey(o => o.OrderId);
        }
    }
}
