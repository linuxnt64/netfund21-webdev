using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace _02_Authentication_Custom.Identity_Roles_Policies_Claims.Data
{
    public class ApplicationUserClaims : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ApplicationUserClaims(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var claimsIdentity = await base.GenerateClaimsAsync(user);

            claimsIdentity.AddClaim(new Claim("UserId", user.Id ?? ""));
            claimsIdentity.AddClaim(new Claim("DisplayName", $"{user.FirstName} {user.LastName}" ?? ""));

            return claimsIdentity;
        }
    }
}
