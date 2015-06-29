using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Newslettersubscription
    {
        public Newslettersubscription()
        {
            PromotionCodes = new HashSet<PromotionCode>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<PromotionCode> PromotionCodes { get; set; }
    }
}
