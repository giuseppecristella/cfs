using System;

namespace Shop.Core.Domain.Promotions
{
    public partial class MagentoPromotionCode
    {
        public int MagentoPromotionCodeId { get; set; }

        public string Code { get; set; }

        public bool Assigned { get; set; }

        public DateTime GeneratedDate { get; set; }
    }
} 
