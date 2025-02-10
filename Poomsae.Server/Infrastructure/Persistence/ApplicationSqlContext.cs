using Microsoft.EntityFrameworkCore;
using Poomsae.Server.Domain.Entitites;

namespace Poomsae.Server.Infrastructure.Persistence
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("users");
            builder.Entity<User>().HasKey(x => x.Id);
            builder.Entity<User>().HasOne(u => u.Club);
            builder.Entity<User>().HasOne<User>(u => u.Master).WithMany(u => u.Students);
            builder.Entity<Sport>().ToTable("sports");
            builder.Entity<Sport>().HasKey(x => x.Id);
            builder.Entity<Kata>().ToTable("katas");
            builder.Entity<Kata>().HasKey(x => x.Id);
            builder.Entity<Step>().ToTable("steps");
            builder.Entity<Step>().HasKey(x => x.Id);
            builder.Entity<Movement>().ToTable("movements");
            builder.Entity<Movement>().HasKey(x => x.Id);
            builder.Entity<Club>().ToTable("clubs");
            builder.Entity<Club>().HasKey(c => c.Id);
            builder.Entity<Club>().HasOne(c => c.Master);
            builder.Entity<Club>().HasOne(c => c.Creator);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}