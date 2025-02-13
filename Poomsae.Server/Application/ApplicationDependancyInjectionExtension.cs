using Poomsae.Server.Application.Services.Authentification.Interfaces;
using Poomsae.Server.Application.Services.Authentification;
using Poomsae.Server.Application.Services.External.Mails;
using Poomsae.Server.Application.Services.Helpers;
using Poomsae.Server.Application.Services.Sports.Interfaces;
using Poomsae.Server.Application.Services.UserSports.Interfaces;
using Poomsae.Server.Application.Services.UserSports;
using Poomsae.Server.Application.Services;
using Poomsae.Server.Application.Utils.Mails;
using Poomsae.Server.Application.Utils.Security;

namespace Poomsae.Server.Application
{
    public static class ApplicationDependancyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.Configure<MailJetSettings>(configuration.GetSection("MailJetSettings"));
            services.AddScoped<SecurityHelpers>();
            services.AddScoped<IMailSender, MailJetSender>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ISportsService, SportsService>();
            services.AddScoped<IUserSportsService, UserSportsService>();
        }
    }
}