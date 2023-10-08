using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RazorScaffolding.Training.Models
{
    public class Purchase
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(80, ErrorMessage = "Description cannot be longer than 80 characters.")]
        [MinLength(5, ErrorMessage = "Description cannot be shorter than 5 characters.")]
        [DisplayName("Description")]
        public string Description { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Establishment cannot be longer than 50 characters.", MinimumLength = 3)]
        [DisplayName("Establishment")]
        public string Establishment { get; set; } = string.Empty;

        [Required(ErrorMessage = "PurchasedAt is required")]
        [DataType(DataType.Date)]
        [DisplayName("PurchasedAt")]
        public DateTime PurchasedAt { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(0, 9999999999.99, ErrorMessage = "Amount must be between 0 and 9999999999.99.")]
        [DataType(DataType.Currency)]
        [MaxLength(10, ErrorMessage = "Amount cannot be longer than 12 characters.")]
        [DisplayName("Amount")]
        public string Amount { get; set; } = string.Empty;

        [Required(ErrorMessage = "PersonId is required")]
        [DisplayName("PersonId")]
        public int PersonId { get; set; }

        public Person? Person { get; set; }
    }
}
