using Microsoft.EntityFrameworkCore;
using Poomsae.Server.Domain.Entitites;
using Poomsae.Server.Domain.Entitites.Base.Interfaces;

namespace Poomsae.Infrastructure.Persistence
{
    public class ApplicationSqlContext : DbContext, IApplicationContext
    {
        public ApplicationSqlContext(DbContextOptions<ApplicationSqlContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Kata> Katas { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<Club> Clubs { get; set; }

        public DbSet<UserSport> UserSports { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //User
            builder.Entity<User>().ToTable("User");
            builder.Entity<User>().HasKey(x => x.Id);
            builder.Entity<User>().HasMany<Club>(u => u.Clubs)
                .WithMany(c => c.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "UserClub",
                    j => j.HasOne<Club>().WithMany().HasForeignKey("ClubId"),
                    j => j.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    j => j.ToTable("UserClubs")
                );

            //User
            builder.Entity<Sport>().ToTable("Sport");
            builder.Entity<Sport>().HasKey(x => x.Id);

            //Kata
            builder.Entity<Kata>().ToTable("Kata");
            builder.Entity<Kata>().HasKey(x => x.Id);

            //Step
            builder.Entity<Step>().ToTable("Step");
            builder.Entity<Step>().HasKey(x => x.Id);

            //Movement
            builder.Entity<Movement>().ToTable("Movement");
            builder.Entity<Movement>().HasKey(x => x.Id);

            //Club
            builder.Entity<Club>().ToTable("Club");
            builder.Entity<Club>().HasKey(c => c.Id);
            builder.Entity<Club>().HasOne<User>(c => c.Master).WithMany();

            //UserSports
            builder.Entity<UserSport>().ToTable("UserSport");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is IBaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((IBaseEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((IBaseEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
                }
            }
            return base.SaveChangesAsync();
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is IBaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((IBaseEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((IBaseEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }

        public new DbSet<T> Set<T>() where T : class => base.Set<T>();
    }
}