using Microsoft.Extensions.Options;
using Poomsae.Application.Utils.Security;

namespace Poomsae.Server.Web.Authentification
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public ApiKeyMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            string? headersKey = context.Request.Headers["xapikey"].FirstOrDefault()?.Split(" ").Last();

            await _next(context);
        }
    }
}