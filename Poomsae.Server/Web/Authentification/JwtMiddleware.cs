using Microsoft.Extensions.Options;
using Poomsae.Server.Application.Interfaces;
using Poomsae.Server.Application.Models.Authentification;
using Poomsae.Server.Application.Models.Errors;
using Poomsae.Server.Application.Services.Helpers;
using Poomsae.Server.Application.Utils.Security;
using System.IdentityModel.Tokens.Jwt;

namespace Poomsae.Server.Web.Authentification
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IAuthService userService, SecurityHelpers securityHelpers)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
                await AttachUserToContext(context, userService, securityHelpers, token);
            await _next(context);
        }

        private async Task AttachUserToContext(HttpContext context, IAuthService userService, SecurityHelpers securityHelpers, string token)
        {
            try
            {
                JwtSecurityToken? jwtToken = securityHelpers.ValidateToken(token);
                if (jwtToken == null)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Token not found");
                    await context.Response.CompleteAsync();
                    return;
                }
                var userEmail = jwtToken.Claims.First(x => x.Type == "email").Value;
                Result<ApplicationUser> usr = userService.Get(userEmail);
                if (usr.IsFailure) throw new Exception();
                context.Items["User"] = usr.Value;
                string? newToken = securityHelpers.generateJwtToken(userEmail);
                if (newToken == null)
                    throw new Exception("Impossible de générer le token rafraichi");
                context.Response.Headers["x-refresh-token"] = newToken;
            }
            catch
            {
                // Ne fais rien si l'user n'existe pas ou il n'est pas authentifier, aucun user n'est a attacher a l'application
            }
        }
    }
}
