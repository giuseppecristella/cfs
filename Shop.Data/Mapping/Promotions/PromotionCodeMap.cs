﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Infrastructure.Domain.Promotions;

namespace Shop.Data.Mapping.Promotions
{
    public partial class PromotionCodeMap : ShopEntityTypeConfiguration<PromotionCode>
    {
        public PromotionCodeMap()
        {
            this.ToTable("PromotionCode");
            HasKey(pr => pr.PromotionId);
            Property(pc => pc.Code).IsRequired().HasMaxLength(20);

            HasRequired(pc => pc.NewsLetterSubscription)
                .WithMany(pc => pc.PromotionCodes)
                .HasForeignKey(pc => pc.NewsLetterSubscriptionId); 

        }
    }
}
