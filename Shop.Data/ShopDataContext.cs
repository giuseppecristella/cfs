using Shop.Core.Domain.Brands;
using Shop.Core.Domain.Categories;
using Shop.Core.Domain.OrderProducts;
using Shop.Core.Domain.Orders;

namespace Shop.Data
{
    using System.Data.Entity;

    public partial class ShopDataContext : DbContext
    {
        public ShopDataContext()
            : base("name=ShopDataContext")
        {
            // http://stackoverflow.com/questions/3600175/the-model-backing-the-database-context-has-changed-since-the-database-was-crea
            Database.SetInitializer<ShopDataContext>(null);
        }

        public virtual DbSet<Newslettersubscription> Newslettersubscriptions { get; set; }
        public virtual DbSet<PromotionCode> PromotionCodes { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Newslettersubscription>().HasKey(e => new { e.Id, e.Email });

            modelBuilder.Entity<Newslettersubscription>().HasKey(e => e.Id);

            modelBuilder.Entity<Newslettersubscription>()
                .HasMany(e => e.PromotionCodes)
                .WithOptional(e => e.Newslettersubscription)
                .HasForeignKey(e => new { e.NewslettersubscriptionId });

            modelBuilder.Entity<Promotion>()
                .HasMany(e => e.PromotionCodes)
                .WithRequired(e => e.Promotion)
                .WillCascadeOnDelete(false);
        }
    }
}
