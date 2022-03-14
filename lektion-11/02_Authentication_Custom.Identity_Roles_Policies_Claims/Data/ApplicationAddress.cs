using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02_Authentication_Custom.Identity_Roles_Policies_Claims.Data
{
    public class ApplicationAddress
    {
        [Key]
        [Column(TypeName = "nvarchar(450)")]
        public string Id { get; set; }
        
        [Required]
        [PersonalData]
        public string StreetName { get; set; }

        [Required]
        [PersonalData]
        public string PostalCode { get; set; }

        [Required]
        [PersonalData]
        public string City { get; set; }
    }
}
