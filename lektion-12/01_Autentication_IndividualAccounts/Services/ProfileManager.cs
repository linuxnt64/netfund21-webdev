using _01_Autentication_IndividualAccounts.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace _01_Autentication_IndividualAccounts.Services
{
    public interface IProfileManager
    {
        Task CreateAsync(UserProfile profile);
        Task<string> GetDisplayNameAsync(string userId);
    }

    public class ProfileManager : IProfileManager
    {
        private readonly ApplicationDbContext _context;

        public ProfileManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(UserProfile userProfile)
        {
            if(await _context.Users.AnyAsync(x => x.Id == userProfile.UserId))
            {
                _context.UserProfiles.Add(userProfile);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> GetDisplayNameAsync(string userId)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.UserId == userId);
            return $"{userProfile?.FirstName} {userProfile?.LastName}";
        }
    }
}
