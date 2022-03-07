using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ContactForm
    {
        [Display(Name = "Namn")]
        [Required(ErrorMessage = "Du måste ange ett namn")]
        [StringLength(256, ErrorMessage = "{0}et måste bestå av minst {2} tecken", MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "E-postadress")]
        [Required(ErrorMessage = "Du måste ange en e-postadress")]
        [EmailAddress(ErrorMessage = "Du måste ange en giltig e-postadress")]
        public string Email { get; set; }

        [Display(Name = "Meddelande")]
        [Required(ErrorMessage = "Du måste ange ett meddelande")]
        [StringLength(256, ErrorMessage = "{0}et måste bestå av minst {2} tecken", MinimumLength = 5)]
        public string Message { get; set; }
    }
}
