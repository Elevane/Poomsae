using Microsoft.Extensions.DependencyInjection;
using Poomsae.Application.Services.Authentification;
using Poomsae.Application.Services.Authentification.Interfaces;
using Poomsae.Application.Services.Generics;
using Poomsae.Application.Services.Generics.Interfaces;
using Poomsae.Application.Services.Helpers;
using System.Reflection;

namespace Poomsae.Application
{
    public static class ApplicationDependancyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<SecurityHelpers>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped(typeof(IGenericReferencesService<,,>), typeof(GenericReferencesService<,,>));
            services.AddScoped(typeof(IGenericUsersService<,,>), typeof(GenericUsersService<,,>));
        }
    }
}