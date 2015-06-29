namespace Shop.Data
{
    using System.Data.Entity;

    public partial class ShopDataContext : DbContext
    {
        public ShopDataContext()
            : base("name=ShopDataContext")
        {
        }

        public virtual DbSet<Newslettersubscription> Newslettersubscriptions { get; set; }
        public virtual DbSet<PromotionCode> PromotionCodes { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }

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
