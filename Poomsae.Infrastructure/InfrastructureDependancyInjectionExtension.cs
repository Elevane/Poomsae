using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poomsae.Server.Infrastructure.Persistence;

namespace Poomsae.Server.Infrastructure
{
    public static class InfrastructureDependancyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationContext, ApplicationSqlContext>(options =>
            {
                string? conString = configuration
                    .GetSection("ConnectionStrings:DefaultConnection")
                    .Value;
                if (conString == null) throw new ArgumentNullException("DefaultConnection secret key could not be found in the environement");
                options.UseMySql(conString, ServerVersion.AutoDetect(conString));
            });
        }
    }
}