using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Infrastructure.Domain.Messages;

namespace Shop.Infrastructure.Domain.Promotions
{
    public partial class PromotionCode
    {
        public int PromotionId { get; set; }

        public string Code { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public bool Used { get; set; }
         
        public Guid NewsLetterSubscriptionId { get; set; }

        public NewsLetterSubscription NewsLetterSubscription { get; set; }
    }
}
