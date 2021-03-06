﻿using System.Collections.Generic;
using Shop.Core.Domain.Promotions;


namespace Shop.Core.Domain.Messages
{
    public partial class NewsLetterSubscription : BaseEntity
    {

        /// <summary>
        /// Gets or sets the subcriber email
        /// </summary> 
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether subscription is active
        /// </summary>
        public bool IsActive { get; set; }

        public virtual ICollection<PromotionCode> PromotionCodes { get; set; }

    }


}
