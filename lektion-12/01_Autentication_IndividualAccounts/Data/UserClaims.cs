using _01_Autentication_IndividualAccounts.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace _01_Autentication_IndividualAccounts.Data
{
    public class UserClaims : UserClaimsPrincipalFactory<IdentityUser, IdentityRole>
    {
        private readonly IProfileManager _profileManager;

        public UserClaims(IProfileManager profileManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
            _profileManager = profileManager;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
        {
            var claimsIdentity = await base.GenerateClaimsAsync(user);
            claimsIdentity.AddClaim(new Claim("UserId", user.Id));
            claimsIdentity.AddClaim(new Claim("DisplayName", await _profileManager.GetDisplayNameAsync(user.Id)));

            return claimsIdentity;
        }
    }
}
