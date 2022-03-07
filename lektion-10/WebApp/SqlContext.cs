using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }
        public SqlContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ContactFormEntity> ContactRequests { get; set; }
    }
}
