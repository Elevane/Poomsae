using Poomsae.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Poomsae.Server.Infrastructure.Persistence
{
    public class ApplicationSqlContext : DbContext, IApplicationContext
    {
        public ApplicationSqlContext(DbContextOptions<ApplicationSqlContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("users");
            builder.Entity<User>().HasKey(x => x.Id);
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
