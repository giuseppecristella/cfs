//using Shop.Core.Domain.Promotions;

//namespace Shop.Data.Mapping.Promotions
//{
//    public partial class PromotionCodeMap : ShopEntityTypeConfiguration<PromotionCode>
//    {
//        public PromotionCodeMap()
//        {
//            ToTable("PromotionCodes");
//            HasKey(pc => pc.Id);

//            Property(pc => pc.Code).IsRequired().HasMaxLength(20);

//            HasOptional(pc => pc.NewsLetterSubscription)
//                .WithMany(pc => pc.PromotionCodes)
//                .HasForeignKey(pc => pc.NewsLetterSubscriptionId);

//            HasOptional(pc => pc.NewsLetterSubscription)
//             .WithMany(pc => pc.PromotionCodes)
//             .HasForeignKey(pc => pc.NewslettersubscriptionEmail);

//            HasRequired(pc => pc.Promotion).WithMany(p => p.PromotionCode);

//        }
//    }
//}
