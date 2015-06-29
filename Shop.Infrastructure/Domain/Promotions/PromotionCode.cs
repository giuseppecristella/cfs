using Shop.Core.Domain.Messages;


namespace Shop.Core.Domain.Promotions
{
    public partial class PromotionCode : BaseEntity
    {

        public string Code { get; set; }

        public bool IsAssigned { get; set; }

        public int NewsLetterSubscriptionId { get; set; }

        public string NewslettersubscriptionEmail { get; set; }

        public virtual NewsLetterSubscription NewsLetterSubscription { get; set; }

        public virtual Promotion Promotion { get; set; }
    }
}
