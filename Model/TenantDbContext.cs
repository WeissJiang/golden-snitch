using golden_snitch.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace golden_snitch.Model
{
    public class TenantDbContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>().HasData(new Tenant { Id = 1, Name = "Super Tenant" });
        }
    }
}
