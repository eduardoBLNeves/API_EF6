using Microsoft.EntityFrameworkCore;

namespace API_EF6.Models
{
    public class _DbContext:DbContext
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Clientes> clientes { get; set; }
    }
}
