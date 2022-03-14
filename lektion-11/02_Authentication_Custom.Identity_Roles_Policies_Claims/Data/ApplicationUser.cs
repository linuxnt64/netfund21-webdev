using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace _02_Authentication_Custom.Identity_Roles_Policies_Claims.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [PersonalData]
        public string FirstName { get; set; }

        [Required]
        [PersonalData]
        public string LastName { get; set; }
    }
}
