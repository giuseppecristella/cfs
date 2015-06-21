using System;
using Shop.Core.Domain.Messages;


namespace Shop.Core.Domain.Promotions
{
    public partial class PromotionCode
    {
        public int PromotionId { get; set; }

        public string Code { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public bool Used { get; set; }
         
        public int NewsLetterSubscriptionId { get; set; }

        public NewsLetterSubscription NewsLetterSubscription { get; set; }
    }
}
