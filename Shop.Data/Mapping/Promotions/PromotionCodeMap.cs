namespace Shop.Data.Mapping.Promotions
{
    public partial class PromotionCodeMap : ShopEntityTypeConfiguration<PromotionCode>
    {
        public PromotionCodeMap()
        {
            ToTable("PromotionCodes");
            HasKey(pc => pc.Id);

            Property(pc => pc.Code).IsRequired().HasMaxLength(20);

            HasOptional(pc => pc.Newslettersubscription)
            .WithMany(pc => pc.PromotionCodes)
            .HasForeignKey(pc => pc.NewslettersubscriptionId);

            HasOptional(pc => pc.Newslettersubscription)
             .WithMany(pc => pc.PromotionCodes)
             .HasForeignKey(pc => pc.NewslettersubscriptionEmail);

            HasRequired(pc => pc.Promotion).WithMany(p => p.PromotionCodes);

        }
    }
}
