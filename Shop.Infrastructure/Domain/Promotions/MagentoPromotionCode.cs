using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Domain.Promotions
{
    public partial class MagentoPromotionCode
    {
        public int MagentoPromotionCodeId { get; set; }

        public string Code { get; set; }

        public bool Assigned { get; set; }

        public DateTime GeneratedDate { get; set; }
    }
} 
