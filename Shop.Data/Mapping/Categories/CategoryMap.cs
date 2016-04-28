namespace Shop.Data.Mapping.Categories
{
    public partial class CategoryMap : ShopEntityTypeConfiguration<Core.Domain.Categories.Category>
    {
        public CategoryMap()
        {
            ToTable("Category");
            HasKey(o => o.Id);

            //HasMany(o => o.)
            //    .WithRequired(o => o.Order)
            //    .HasForeignKey(o => o.OrderId);
        }
    }
}
