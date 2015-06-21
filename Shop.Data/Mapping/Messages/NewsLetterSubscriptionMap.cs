using Shop.Core.Domain.Messages;
 

namespace Shop.Data.Mapping.Messages
{
    public class NewsLetterSubscriptionMap: ShopEntityTypeConfiguration<NewsLetterSubscription>
    {
        public NewsLetterSubscriptionMap()
        {
            ToTable("NewsLetterSubscription");
            HasKey(nls => nls.Id);

            Property(nls => nls.Email).IsRequired().HasMaxLength(255);
        }
    }
}
