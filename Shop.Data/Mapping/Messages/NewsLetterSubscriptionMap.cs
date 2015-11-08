using Shop.Core.Domain.Messages;


namespace Shop.Data.Mapping.Messages
{
    public class NewsLetterSubscriptionMap : ShopEntityTypeConfiguration<NewsLetterSubscription>
    {
        public NewsLetterSubscriptionMap()
        {
            ToTable("NewsLetterSubscriptions");
            HasKey(nls => nls.Id);
            // HasKey(nls => nls.Email);


            Property(nls => nls.Email).IsRequired().HasMaxLength(255);

        }
    }
}
