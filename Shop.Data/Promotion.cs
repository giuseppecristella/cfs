namespace Shop.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Promotion
    {
        public Promotion()
        {
            PromotionCodes = new HashSet<PromotionCode>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<PromotionCode> PromotionCodes { get; set; }
    }
}
