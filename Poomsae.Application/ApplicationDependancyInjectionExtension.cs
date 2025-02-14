using Poomsae.Application.Services.Authentification.Interfaces;
using Poomsae.Application.Services.Authentification;
using Poomsae.Application.Services.External.Mails;
using Poomsae.Application.Services.Helpers;
using Poomsae.Application.Services.Sports.Interfaces;
using Poomsae.Application.Services.UserSports.Interfaces;
using Poomsae.Application.Services.UserSports;
using Poomsae.Application.Services;
using Poomsae.Application.Utils.Mails;
using Poomsae.Application.Utils.Security;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Poomsae.Application
{
    public static class ApplicationDependancyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<SecurityHelpers>();
            services.AddScoped<IMailSender, MailJetSender>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ISportsService, SportsService>();
            services.AddScoped<IUserSportsService, UserSportsService>();
        }
    }
}