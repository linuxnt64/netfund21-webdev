using _02_Authentication_Custom.Identity_Roles_Policies_Claims.Data;
using Microsoft.EntityFrameworkCore;

namespace _02_Authentication_Custom.Identity_Roles_Policies_Claims.Services
{
    public interface IAddressManager
    {
        Task CreateUserAddressAsync(ApplicationUser user, ApplicationAddress address);
    }


    public class AddressManager : IAddressManager
    {
        private readonly ApplicationDbContext _context;

        public AddressManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateUserAddressAsync(ApplicationUser user, ApplicationAddress address)
        {
            var userAddress = new ApplicationUserAddress();

            var _address = await _context.Addresses.FirstOrDefaultAsync(x => x.StreetName == address.StreetName && x.PostalCode == address.PostalCode);
            if(_address != null)
            {
                userAddress = new ApplicationUserAddress { UserId = user.Id, AddressId = _address.Id };
            }
            else
            {
                address.Id = Guid.NewGuid().ToString();
                _context.Addresses.Add(address);
                await _context.SaveChangesAsync();

                userAddress = new ApplicationUserAddress { UserId = user.Id, AddressId = address.Id };
            }

            _context.UserAddresses.Add(userAddress);
            await _context.SaveChangesAsync();
        }
    }
}
