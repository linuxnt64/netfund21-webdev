using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace WebApi
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public virtual DbSet<ServiceEntity> Services { get; set; }
    }
}
