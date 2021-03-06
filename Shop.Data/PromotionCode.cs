namespace Shop.Data
{
    using System.ComponentModel.DataAnnotations;

    public partial class PromotionCode
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        public bool IsAssigned { get; set; }

        public int? NewslettersubscriptionId { get; set; }

        [StringLength(100)]
        public string NewslettersubscriptionEmail { get; set; }

        public int PromotionId { get; set; }

        public virtual Newslettersubscription Newslettersubscription { get; set; }

        public virtual Promotion Promotion { get; set; }
    }
}
