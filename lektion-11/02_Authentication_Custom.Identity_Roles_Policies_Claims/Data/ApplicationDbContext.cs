using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _02_Authentication_Custom.Identity_Roles_Policies_Claims.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<ApplicationAddress> Addresses { get; set; }
        public virtual DbSet<ApplicationUserAddress> UserAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUserAddress>().HasKey("UserId", "AddressId");

            base.OnModelCreating(builder);
        }
    }
}
