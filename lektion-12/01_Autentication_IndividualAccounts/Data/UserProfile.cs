using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_Autentication_IndividualAccounts.Data
{
    public class UserProfile
    {
        [Key]
        [Column(TypeName = "nvarchar(450)")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string StreetName { get; set; } = string.Empty;

        [Required]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string UserId { get; set; } = string.Empty;

    }
}
