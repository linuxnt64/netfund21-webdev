using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_Autentication_IndividualAccounts.Models.Forms
{

    public class RegisterForm
    {
        [Display(Name = "Förnamn")]
        [Required(ErrorMessage = "Du måste ange ett förnamn.")]
        [RegularExpression(@"^([a-öA-Ö]+?)([-][a-öA-Ö]+)*?$", ErrorMessage = "Du måste ange ett giltigt förnamn")]
        public string FirstName { get; set; } = "";

        [Display(Name = "Efternamn")]
        [Required(ErrorMessage = "Du måste ange ett efternamn.")]
        [RegularExpression(@"^([a-öA-Ö]+?)([-\s][a-öA-Ö]+)*?$", ErrorMessage = "Du måste ange ett giltigt efternamn")]
        public string LastName { get; set; } = "";

        [Display(Name = "Gatuadress")]
        [Required(ErrorMessage = "Du måste ange en gatuadress.")]
        [RegularExpression(@"^([a-öA-Ö]+?)([\s][0-9]+)*?$", ErrorMessage = "Du måste ange en giltig gatuadress")]
        public string StreetName { get; set; } = "";

        [Display(Name = "Postnummer (ex. 123 45)")]
        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage = "Du måste ange ett postnummer.")]
        [RegularExpression(@"^\d{3}(\s\d{2})?$$", ErrorMessage = "Du måste ange ett giltigt postnummer")]
        public string PostalCode { get; set; } = "";

        [Display(Name = "Ort")]
        [Required(ErrorMessage = "Du måste ange en ort.")]
        [RegularExpression(@"^([a-öA-Ö]+?)([-\s][a-öA-Ö]+)*?$", ErrorMessage = "Du måste ange ett giltigt ortnamn")]
        public string City { get; set; } = "";

        [Display(Name = "E-postadress")]
        [Required(ErrorMessage = "Du måste ange en e-postadress.")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Du måste ange en giltig e-postadress")]
        public string Email { get; set; } = "";

        [Display(Name = "Lösenord")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Du måste ange ett lösenord.")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Du måste ange ett giltigt lösenord")]
        public string Password { get; set; } = "";

        [Display(Name = "Bekräfta Lösenord")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Du måste bekräfta lösenordet.")]
        [Compare("Password", ErrorMessage = "Lösenordet matchar inte.")]
        public string ConfirmPassword { get; set; } = "";

        [NotMapped]
        public string RoleName { get; set; } = "user";
        
    }
}
