using golden_snitch.Entities.Projects;
using golden_snitch.Entities.Scheduler;
using golden_snitch.Entities.Tickets;
using golden_snitch.Entities.Users;
using Microsoft.EntityFrameworkCore;
using static golden_snitch.Entities.Users.User;
using Job = golden_snitch.Entities.Scheduler.Job;

namespace golden_snitch.Entities;

public class EntitiesDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    // ticket section
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketTag> TicketTag { get; set; }
    public DbSet<TicketHour> TicketTags { get; set; }
    public DbSet<TicketComment> TicketComments { get; set; }

    // scheduler section

    public DbSet<Project> Projects { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<JobTag> JobTags { get; set; }


    public EntitiesDbContext(DbContextOptions<EntitiesDbContext> options)
            : base(options)
    {
    }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry is { State: EntityState.Modified, Entity: GenericRecord entity })
            {
                entity.LastModifiedDateUTC = DateTime.UtcNow;
            }
        }

        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(GenericRecord).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property("CreationDateUTC")
                    .HasDefaultValueSql("now()");
                modelBuilder.Entity(entityType.ClrType)
                    .Property("LastModifiedDateUTC")
                    .HasDefaultValueSql("now()");
                modelBuilder.Entity(entityType.ClrType)
                    .Property("TimeZone")
                    .HasDefaultValue("Australia/Melbourne");
            }
        }

        modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Super Admin",
                    Email = "*******",
                    PrivilegeLevel = UserPrivilegeLevel.Super,
                },
                new User
                {
                    Id = 2,
                    Name = "Weiss",
                    Email = "*******",
                    PrivilegeLevel = UserPrivilegeLevel.Standard
                }
            );

        modelBuilder.Entity<Job>()
            .HasKey(x => x.Id);
    }
}
