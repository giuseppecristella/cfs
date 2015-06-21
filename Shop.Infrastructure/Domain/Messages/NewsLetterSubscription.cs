using System;
using System.Collections.Generic;
using Shop.Core;
using Shop.Infrastructure.Domain.Promotions;

namespace Shop.Infrastructure.Domain.Messages
{
    public partial class NewsLetterSubscription: BaseEntity
    {
        /// <summary>
        /// Gets or sets the newsletter subscription GUID
        /// </summary>
        public Guid NewsLetterSubscriptionGuid { get; set; }

        /// <summary>
        /// Gets or sets the subcriber email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether subscription is active
        /// </summary>
        public bool Active { get; set; }

        public ICollection<PromotionCode> PromotionCodes { get; set; }

        /// <summary>
        /// Gets or sets the date and time when subscription was created
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }
    }

  
}
