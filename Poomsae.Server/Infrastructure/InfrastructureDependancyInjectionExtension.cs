using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Poomsae.Server.Infrastructure.Persistence;
using System.Threading.RateLimiting;

namespace Poomsae.Server.Infrastructure
{
    public static class InfrastructureDependancyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRateLimiter(o =>
            {
                o.OnRejected = (context, cancellationToken) =>
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                    context.HttpContext.Response.WriteAsync("Maxi mum request limit reached.");
                    return new ValueTask();
                };
                o.AddFixedWindowLimiter(policyName: "poomsae", options =>
                {
                    options.PermitLimit = 10;
                    options.Window = TimeSpan.FromSeconds(5);
                    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    options.QueueLimit = 2;
                });
            });

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