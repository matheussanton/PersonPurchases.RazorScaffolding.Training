using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RazorScaffolding.Training.Models
{
    public class Person
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [DisplayName("Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        [DisplayName("Email")]
        public string Email { get; set; } = string.Empty;

        public List<Purchase> Purchases { get; set; } = new();
    }
}
