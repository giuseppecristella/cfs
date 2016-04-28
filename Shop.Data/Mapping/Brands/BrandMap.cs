using Shop.Core.Domain.Brands;

namespace Shop.Data.Mapping.Brands
{
    public partial class BrandMap : ShopEntityTypeConfiguration<Brand>
    {
        public BrandMap()
        {
            ToTable("Brand");
            HasKey(b => b.Id);

            HasMany(b => b.Categories).WithMany(c => c.Brands);
        }
    }
}
